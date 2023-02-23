using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private BoothRepository booths;

        public Controller()
        {
            booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            IBooth booth = new Booth(booths.Models.Count + 1, capacity);
            booths.AddModel(booth);

            return String.Format(OutputMessages.NewBoothAdded, booth.BoothId, capacity);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName,
            string delicacyName)
        {
            var booth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);

            if (delicacyTypeName != nameof(Stolen) &&
                delicacyTypeName != nameof(Gingerbread))
            {
                return String
                    .Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            if (booth.DelicacyMenu.Models.Any(x => x.Name == delicacyName))
            {
                return String
                    .Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            IDelicacy delicacy;

            if (delicacyTypeName == nameof(Gingerbread))
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else
            {
                delicacy = new Stolen(delicacyName);
            }

            booth.DelicacyMenu.AddModel(delicacy);

            return string
                .Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string AddCocktail(int boothId, string cocktailTypeName,
            string cocktailName, string size)
        {
            var booth = booths.Models.First(x => x.BoothId == boothId);

            if (cocktailTypeName != nameof(Hibernation) &&
                cocktailTypeName != nameof(MulledWine))
            {
                return String.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (size != "Small" && size != "Middle" && size != "Large")
            {
                return String.Format(OutputMessages.InvalidCocktailSize, size);
            }

            if (booth.CocktailMenu.Models
                .Any(x => x.Name == cocktailName && x.Size == size))
            {
                return String
                    .Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            ICocktail cocktailToAdd;

            if (cocktailTypeName == nameof(Hibernation))
            {
                cocktailToAdd = new Hibernation(cocktailName, size);
            }
            else
            {
                cocktailToAdd = new MulledWine(cocktailName, size);
            }

            booth.CocktailMenu.AddModel(cocktailToAdd);

            return String.Format(OutputMessages
                .NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }
        public string ReserveBooth(int countOfPeople)
        {
            var boothToWorkWith = booths.Models
                .Where(x => x.IsReserved == false && x.Capacity >= countOfPeople)
                .OrderBy(x => x.Capacity)
                .ThenByDescending(x => x.BoothId)
                .FirstOrDefault();

            if (boothToWorkWith == null)
            {
                return String.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            boothToWorkWith.ChangeStatus();

            return String.Format(OutputMessages
                .BoothReservedSuccessfully, boothToWorkWith.BoothId, countOfPeople);
        }
        public string TryOrder(int boothId, string order)
        {
            var booth = booths.Models
                .First(x => x.BoothId == boothId);

            string[] args = order.Split('/');

            string itemTypeName = args[0];
            string itemName = args[1];
            int countOfPieces = int.Parse(args[2]);

            string size = " ";

            if (itemTypeName == nameof(Hibernation) || itemTypeName == nameof(MulledWine))
            {
                size = args[3];
            }

            if (itemTypeName != nameof(Hibernation) &&
                itemTypeName != nameof(MulledWine) &&
                itemTypeName != nameof(Gingerbread) &&
                itemTypeName != nameof(Stolen))
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            if (booth.CocktailMenu.Models
                    .FirstOrDefault(x => x.Name == itemName) == null &&
                booth.DelicacyMenu.Models
                    .FirstOrDefault(x => x.Name == itemName) == null)
            {
                return String
                    .Format(OutputMessages
                        .NotRecognizedItemName, itemTypeName, itemName);
            }

            if (size != " ") // Cocktail
            {
                var item = booth.CocktailMenu.Models
                    .FirstOrDefault(x => x.Name == itemName &&
                                         x.Size == size &&
                                         x.GetType().Name == itemTypeName);
                if (item != null)
                {
                    booth.UpdateCurrentBill(item.Price * countOfPieces);

                    return string
                        .Format(OutputMessages
                            .SuccessfullyOrdered, boothId, countOfPieces, itemName);
                }

                return String.Format(OutputMessages.CocktailStillNotAdded, size, itemName);
            }
            else
            {
                
            }

        }

        public string BoothReport(int boothId)
        {
            throw new NotImplementedException();
        }

        public string LeaveBooth(int boothId)
        {
            throw new NotImplementedException();
        }
    }
}
