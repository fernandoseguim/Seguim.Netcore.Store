using Flunt.Notifications;
using Flunt.Validations;

namespace Seguim.Netcore.Store.Domain.StoreContext.ValueObjects {
    public class Email : Notifiable
    {
        public Email (string address) {
            Address = address;
            AddNotifications(new Contract()
                .Requires()            
                .IsEmail(this.Address, "Email", "This e-mail is not valid")
            );
        }

        public string Address { get; private set; }

        public override string ToString () {
            return Address;
        }

    }
}