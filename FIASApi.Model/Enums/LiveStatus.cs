namespace FIASApi.Model.Enums
{
    /// <summary>
    /// Представляет собой перечисление статусов актуальности адресного объекта ФИАС на текущую дату.
    /// </summary>
    public enum LiveStatus
    {
        /// <summary>
        /// Не актуальный.
        /// </summary>
        NotRelevant = 0,
        /// <summary>
        /// Актуальный.
        /// </summary>
        Relevant = 1
    }
}
