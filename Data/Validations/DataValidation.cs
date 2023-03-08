namespace BookDepot.Data.Validations;

public static class DataValidation
{
    public static class Book
    {
        public const int TitleMaxLength = 100;

        public const int DescriptionMaxLength = 500;
    }

    public static class Author
    {
        public const int NameMaxLength = 100;
    }
}
