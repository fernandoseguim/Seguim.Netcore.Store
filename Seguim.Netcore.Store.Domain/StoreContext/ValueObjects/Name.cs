using Flunt.Notifications;
using Flunt.Validations;

namespace Seguim.Netcore.Store.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public bool IsValid()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(this.FirstName, 3, nameof(this.FirstName), "Firstname does not be lower than 3 characters")
                .HasMinLen(this.FirstName, 2, nameof(this.FirstName), "Lastname does not be lower than 2 characters")
            );
            
            return Valid;
        }
    }
}