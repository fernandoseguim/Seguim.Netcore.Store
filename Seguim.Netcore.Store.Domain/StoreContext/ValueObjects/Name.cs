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
            
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(this.FirstName, 3, nameof(this.FirstName), "Firstname does not be lower than 3 characters")
                .HasMinLen(this.LastName, 2, nameof(this.LastName), "Lastname does not be lower than 2 characters")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}