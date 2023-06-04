namespace Domain.Records
{
    public record UserRecord(int Id, string Name, string Surname, string Email, string PhoneNumber, string TaxNumber, GroupRecord? Group);
}
