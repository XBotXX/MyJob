using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WarehouseShop.ClientClasses
{
    // customer service class
    public class AdminClientIndivid
    {
        public static Entities context = new Entities();

        public static string ComboboxCountry = "";

        public static string LikeClient = "";

        // Main List
        public static List<AdminClientIndivid> ListAdminClientLegal = new List<AdminClientIndivid>();

        public string name { get; set; }
        public string surname { get; set; }
        public decimal telephone { get; set; }
        public string email { get; set; }
        public DateTime dateofbith { get; set; }
        public string address { get; set; }
        public string country { get; set; }
        public string nomercard { get; set; }
        public decimal secretcode { get; set; }
        public DateTime datecard { get; set; }

        // method for creating a list and populating it with data
        public static void MakerList()
        {
            ListAdminClientLegal.Clear();

            // BD
            var dgDATA = from client in context.Individuals
                         join coutry in context.Country on client.IdCountry equals coutry.IdCountry
                         join clientid in context.Clients on client.IdClient equals clientid.IdClient
                         join clienttocard in context.ClientsToCardsClients on clientid.IdClient equals clienttocard.IdClient
                         join clientcard in context.CardsClients on clienttocard.IdCardClient equals clientcard.IdCardClient
                         select new
                         {
                             name = client.Name,
                             surname = client.Surname,
                             dateofbith = client.DateOfBirth,
                             telephone = client.Telephone,
                             email = client.Email,
                             address = client.Address,
                             country = coutry.NameCountry,
                             nomercard = clientcard.NomerCard,
                             secretcode = clientcard.SecretCode,
                             datecard = clientcard.DateCardClient
                         };

            //ADD in List
            foreach (var s in dgDATA.ToList())
            {
                AdminClientIndivid.ListAdminClientLegal.Add(new AdminClientIndivid
                {
                    name = s.name,
                    surname = s.surname,
                    telephone = s.telephone.Value,
                    email = s.email,
                    dateofbith = s.dateofbith.Value,
                    address = s.address,
                    country = s.country,
                    nomercard = s.nomercard,
                    secretcode = s.secretcode,
                    datecard = s.datecard
                });
            }
        }


        // method to populate the table
        public static void MakerDataGrid(DataGrid dataGrid, bool check)
        {
            // all data
            if (check)
            {
                List<AdminClientIndivid> res = ListAdminClientLegal.ToList();

                if (ComboboxCountry != "")
                {
                    res = res.Where(i => i.country == ComboboxCountry).ToList();
                }
                if (LikeClient != "")
                {
                    res = res.Where(i => i.name.Contains($"{LikeClient}")).ToList();
                }
                dataGrid.ItemsSource = res.ToList();
            }
            // select data
            else
            {
                var res = ListAdminClientLegal.Select(i => new { i.name, 
                                                                 i.surname, 
                                                                 i.telephone, 
                                                                 i.email, 
                                                                 i.dateofbith, 
                                                                 i.address, 
                                                                 i.country }).ToList();

                if (ComboboxCountry != "")
                {
                    res = res.Where(i => i.country == ComboboxCountry).ToList();
                }
                if (LikeClient != "")
                {
                    res = res.Where(i => i.name.Contains($"{LikeClient}")).ToList();
                }
                dataGrid.ItemsSource = res.ToList();
            }
        }
    }
}