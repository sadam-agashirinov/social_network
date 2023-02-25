namespace Domain.Entity;

/// <summary>
/// Блоггер
/// </summary>
public class Blogger : Common.Entity
{
    /// <summary>
    /// Ник
    /// </summary>
    public string Nickname { get; set; } = null!;
    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; set; } = null!;
    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; set; } = null!;
    /// <summary>
    /// Дата и время создания аккаунта
    /// </summary>
    public DateTime Created { get; set; }

    /// <summary>
    /// Посты блогера
    /// </summary>
    public ICollection<Post> Posts { get; set; }
}