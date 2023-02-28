namespace BookDepot.Data.Validations;

public static class DataValidation
{
    public static class Book
    {
        public const int TitleMaxLength = 50;

        public const int DescriptionMaxLength = 500;
    }

    public static class Author
    {
        public const int NameMaxLength = 50;
    }
}
