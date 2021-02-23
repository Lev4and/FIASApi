namespace FIASApi.Model.Enums
{
    /// <summary>
    /// Представляет собой перечисление уровней адресного объекта.
    /// </summary>
    public enum LevelAddressObject
    {
        /// <summary>
        /// Уровень региона.
        /// </summary>
        Region = 1,
        /// <summary>
        /// Уровень района.
        /// </summary>
        Area = 3,
        /// <summary>
        /// Уровень города.
        /// </summary>
        City = 4,
        /// <summary>
        /// Уровень городских и сельских поселений.
        /// </summary>
        Place = 6,
        /// <summary>
        /// Уровень улицы.
        /// </summary>
        Street = 7
    }
}
