using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Utilities.Messages;

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
            int id = booths.Models.Count + 1;
            Booth booth = new Booth(id, capacity);
            booths.AddModel(booth);

            return String.Format(OutputMessages.NewBoothAdded, id, capacity);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IDelicacy delicacy = null;

            if (delicacyTypeName == nameof(Gingerbread))
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else if (delicacyTypeName == nameof(Stolen))
            {
                delicacy = new Stolen(delicacyName);
            }
            else
            {
                return String.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            var booth = booths.Models.First(x => x.BoothId == boothId);

            if (booth.DelicacyMenu.Models.Any(x => x.Name == delicacyName))
            {
                return String.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            booth.DelicacyMenu.AddModel(delicacy);

            return String.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            ICocktail cocktail = null;

            if (cocktailTypeName == nameof(MulledWine))
            {
                cocktail = new MulledWine(cocktailName, size);
            }
            else if (cocktailTypeName == nameof(Hibernation))
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            else
            {
                return String.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (size != "Large" && size != "Middle" && size != "Small")
            {
                return String.Format(OutputMessages.InvalidCocktailSize, size);
            }

            var booth = booths.Models.First(x => x.BoothId == boothId);

            if (booth.CocktailMenu.Models.Any(x => x.Name == cocktailName && x.Size == size))
            {
                return String.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            booth.CocktailMenu.AddModel(cocktail);

            return String.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string ReserveBooth(int countOfPeople)
        {
            var booth = booths.Models
                .Where(x => !x.IsReserved && x.Capacity >= countOfPeople)
                .OrderBy(c => c.Capacity)
                .ThenByDescending(b => b.BoothId)
                .FirstOrDefault();

            if (booth == null)
            {
                return String.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            booth.ChangeStatus();

            return String.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            var booth = booths.Models.First(x => x.BoothId == boothId);

            string[] orderArgs = order
                .Split("/", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var itemTypeName = orderArgs[0];
            var itemName = orderArgs[1];
            var countOfOrderedPieces = int.Parse(orderArgs[2]);
            var size = "";

            if (itemTypeName == nameof(MulledWine) || itemTypeName == nameof(Hibernation))
            {
                size = orderArgs[3];
            }

            if (itemTypeName != nameof(MulledWine) && itemTypeName != nameof(Hibernation) && itemTypeName != nameof(Gingerbread) && itemTypeName != nameof(Stolen))
            {
                return String.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            if (!booth.CocktailMenu.Models.Any(x => x.Name == itemName) && !booth.DelicacyMenu.Models.Any(x => x.Name == itemName))
            {
                return String.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
            }

            if (itemTypeName == nameof(MulledWine) || itemTypeName == nameof(Hibernation))
            {
                var drinkToOrder =
                    booth.CocktailMenu.Models.FirstOrDefault(x => x.Name == itemName && x.Size == size && x.GetType().Name == itemTypeName);

                if (drinkToOrder == null)
                {
                    return String.Format(OutputMessages.CocktailStillNotAdded, size, itemName);
                }

                booth.UpdateCurrentBill(drinkToOrder.Price * countOfOrderedPieces);

                return String.Format(OutputMessages.SuccessfullyOrdered, boothId, countOfOrderedPieces, itemName);
            }

            var mealToOrder =
                booth.DelicacyMenu.Models.FirstOrDefault(
                    x => x.Name == itemName && x.GetType().Name == itemTypeName);

            if (mealToOrder == null)
            {
                return String.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);
            }

            booth.UpdateCurrentBill(mealToOrder.Price * countOfOrderedPieces);

            return String.Format(OutputMessages.SuccessfullyOrdered, boothId, countOfOrderedPieces, itemName);
        }

        public string LeaveBooth(int boothId)
        {
            var booth = booths.Models.First(x => x.BoothId == boothId);

            booth.ChangeStatus();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Bill {booth.CurrentBill:F2} lv");

            booth.Charge();

            sb.AppendLine($"Booth {boothId} is now available!");

            return sb.ToString().TrimEnd();
        }

        public string BoothReport(int boothId)
        {
            var booth = booths.Models.First(x => x.BoothId == boothId);

            return booth.ToString();
        }
    }
}
