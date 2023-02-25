namespace Domain.Entity;

/// <summary>
/// Пост блоггера
/// </summary>
public class Post : Common.Entity
{
    /// <summary>
    /// Текст поста
    /// </summary>
    public string Text { get; set; }
    /// <summary>
    /// Дата и время создания поста
    /// </summary>
    public DateTime Created { get; set; }
    /// <summary>
    /// Идентификатор блоггера
    /// </summary>
    public Guid BloggerId { get; set; }

    /// <summary>
    /// Блоггер которому принадлежит пост
    /// </summary>
    public Blogger Blogger { get; set; }
}