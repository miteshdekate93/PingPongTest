namespace PingPong.Tests;

/// <summary>
/// Unit tests for Player model validation and business rules.
/// Demonstrates xUnit testing patterns with clean arrange/act/assert structure.
/// </summary>
public class PlayerModelTests
{
    [Fact]
    public void Player_WithValidData_ShouldHaveCorrectProperties()
    {
        // Arrange & Act
        var player = new PlayerDto
        {
            Id = 1,
            Name = "John Doe",
            Ranking = 1500,
            GamesPlayed = 10,
            Wins = 7
        };

        // Assert
        Assert.Equal(1, player.Id);
        Assert.Equal("John Doe", player.Name);
        Assert.Equal(1500, player.Ranking);
        Assert.Equal(10, player.GamesPlayed);
        Assert.Equal(7, player.Wins);
    }

    [Fact]
    public void Player_WinRate_ShouldCalculateCorrectly()
    {
        // Arrange
        var player = new PlayerDto { GamesPlayed = 10, Wins = 7 };

        // Act
        var winRate = player.WinRate;

        // Assert
        Assert.Equal(70.0, winRate, precision: 1);
    }

    [Fact]
    public void Player_WinRate_WhenNoGamesPlayed_ShouldReturnZero()
    {
        // Arrange
        var player = new PlayerDto { GamesPlayed = 0, Wins = 0 };

        // Act
        var winRate = player.WinRate;

        // Assert
        Assert.Equal(0.0, winRate);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Player_WithInvalidName_ShouldFailValidation(string? name)
    {
        // Arrange
        var player = new PlayerDto { Name = name! };

        // Act
        var isValid = player.IsValid();

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void Player_WithValidName_ShouldPassValidation()
    {
        // Arrange
        var player = new PlayerDto { Name = "Jane Smith" };

        // Act
        var isValid = player.IsValid();

        // Assert
        Assert.True(isValid);
    }
}

public class PlayerServiceTests
{
    private readonly List<PlayerDto> _players;
    private readonly FakePlayerRepository _repository;
    private readonly PlayerService _service;

    public PlayerServiceTests()
    {
        _players = new List<PlayerDto>
        {
            new() { Id = 1, Name = "Alice", Ranking = 1800, GamesPlayed = 20, Wins = 15 },
            new() { Id = 2, Name = "Bob", Ranking = 1600, GamesPlayed = 15, Wins = 8 },
            new() { Id = 3, Name = "Charlie", Ranking = 1400, GamesPlayed = 10, Wins = 4 },
        };
        _repository = new FakePlayerRepository(_players);
        _service = new PlayerService(_repository);
    }

    [Fact]
    public void GetAllPlayers_ShouldReturnAllPlayers()
    {
        // Act
        var result = _service.GetAll();

        // Assert
        Assert.Equal(3, result.Count());
    }

    [Fact]
    public void GetPlayerById_WithValidId_ShouldReturnCorrectPlayer()
    {
        // Act
        var result = _service.GetById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Alice", result.Name);
    }

    [Fact]
    public void GetPlayerById_WithInvalidId_ShouldReturnNull()
    {
        // Act
        var result = _service.GetById(999);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void AddPlayer_WithValidPlayer_ShouldIncreaseCount()
    {
        // Arrange
        var newPlayer = new PlayerDto { Id = 4, Name = "Diana", Ranking = 1700, GamesPlayed = 5, Wins = 3 };

        // Act
        _service.Add(newPlayer);
        var all = _service.GetAll();

        // Assert
        Assert.Equal(4, all.Count());
        Assert.Contains(all, p => p.Name == "Diana");
    }

    [Fact]
    public void DeletePlayer_WithValidId_ShouldRemovePlayer()
    {
        // Act
        _service.Delete(1);
        var all = _service.GetAll();

        // Assert
        Assert.Equal(2, all.Count());
        Assert.DoesNotContain(all, p => p.Id == 1);
    }

    [Fact]
    public void GetTopPlayers_ShouldReturnPlayersSortedByRanking()
    {
        // Act
        var top = _service.GetTopPlayers(2).ToList();

        // Assert
        Assert.Equal(2, top.Count);
        Assert.Equal("Alice", top[0].Name);   // Highest ranking
        Assert.Equal("Bob", top[1].Name);
    }
}

// ── Supporting types (kept in test project for simplicity) ────────────────────

public class PlayerDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Ranking { get; set; }
    public int GamesPlayed { get; set; }
    public int Wins { get; set; }

    public double WinRate => GamesPlayed == 0 ? 0.0 : (double)Wins / GamesPlayed * 100;

    public bool IsValid() => !string.IsNullOrWhiteSpace(Name);
}

public interface IPlayerRepository
{
    IEnumerable<PlayerDto> GetAll();
    PlayerDto? GetById(int id);
    void Add(PlayerDto player);
    void Delete(int id);
}

public class FakePlayerRepository : IPlayerRepository
{
    private readonly List<PlayerDto> _store;
    public FakePlayerRepository(List<PlayerDto> initial) => _store = initial;
    public IEnumerable<PlayerDto> GetAll() => _store;
    public PlayerDto? GetById(int id) => _store.FirstOrDefault(p => p.Id == id);
    public void Add(PlayerDto p) => _store.Add(p);
    public void Delete(int id) => _store.RemoveAll(p => p.Id == id);
}

public class PlayerService
{
    private readonly IPlayerRepository _repo;
    public PlayerService(IPlayerRepository repo) => _repo = repo;
    public IEnumerable<PlayerDto> GetAll() => _repo.GetAll();
    public PlayerDto? GetById(int id) => _repo.GetById(id);
    public void Add(PlayerDto p) => _repo.Add(p);
    public void Delete(int id) => _repo.Delete(id);
    public IEnumerable<PlayerDto> GetTopPlayers(int count) =>
        _repo.GetAll().OrderByDescending(p => p.Ranking).Take(count);
}
