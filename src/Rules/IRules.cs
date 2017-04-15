namespace Rules
{
    public interface IRules<TEntity>
    {
        string Message { get; }
        void Validate(TEntity entity);
        StatusOfValidation StatusOfValidation { get; }
    }
}
