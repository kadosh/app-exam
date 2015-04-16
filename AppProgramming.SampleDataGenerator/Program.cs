using AppProgramming.DataModel.Models;
using AppProgramming.DataModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProgramming.SampleDataGenerator
{
    class Program
    {
        #region Other stuff
        private static DateTime start = new DateTime(2012, 1, 1);

        private static Random randomizer = new Random();

        private static IList<int> cities = new List<int>() { 1, 2, 3, 4, 5 };

        private static IList<int> bloodTypes = new List<int>() { 1, 2, 3, 4, 5, 6 };

        private static IList<string> domains = new List<string>() { "gmail.com", "yahoo.com", "hotmail.com", "facebook.com" };

        private static IList<int> years = new List<int>();

        private static IList<int> months = new List<int>();

        private static IList<int> days = new List<int>();
        #endregion

        #region Static names

        private static IList<string> addresses2 = new List<string>()
        {
            "Alcalde Barranquitas",
                "Artesanos",
                "Autocinema",
                "Balcones de Huentitán",
                "Barranquitas",
                "Batallones de San Patricio",
                "Carballo",
                "Centro Barranquitas",
                "Chapultepec Country",
                "Circunvalación Metro",
                "Colinas de La Normal",
                "Colomos Independencia",
                "Colonial Independencia",
                "Condominio San Antonio",
                "Coto Residencial Jardines del country",
                "División del Norte",
                "Dr. Atl",
                "El Jagüey",
                "El Refugio",
                "El Retiro",
                "Estadio Poniente",
                "Fraccionamiento Ritz",
                "Guadalupana",
                "Huentitán El Bajo",
                "Huerta de Alcaraz",
                "Independencia",
                "Independencia Poniente",
                "Infonavit Rancho Nuevo",
                "Infonavit Zoológico Planetario",
                "Jardines Alcalde",
                "Jardines de Independencia",
                "Jardines de Atemajac",
                "Jardines del country",
                "Jesús",
                "Josefina López de Isaac",
                "La Normal",
                "Las Lomas Independencia",
                "Lomas del Paraíso",
                "Lomas Independencia",
                "Mezquitán Country",
                "Miraflores",
                "Montecasino",
                "Niños Héroes",
                "Observatorio",
                "Panorámica de Huentitán",
                "Parques Independencia",
                "Paseos Independencia",
                "Rancho Nuevo",
                "Real Huentitán",
                "Residencial San Elías",
                "Ricardo Flores Magón",
                "Rinconada del Planetario",
                "Rinconada El Paraíso",
                "Rinconada Real Huentitán",
                "Sagrada Familia",
                "Santa Elena Alcalde",
                "Santa Elena Estadio",
                "Transito",
                "Unidad Habitacional Alcalde",
                "Villas Alcalde",
                "Villas de San Juan",
                "Villas de Santa María",
                "Villas del Real",
                "Villas Magnolias",
                "Vistas del Estadio"
        };

        private static IList<string> addresses = new List<string>() 
        {
            "General Vicente Riva Palacio",
                "José Ma. Morelos",
                "Ocampo(poniente)",
                "Raymundo Jardón (oriente)",
                "José María Abasolo",
                "Amado Nervo",
                "Hidalgo",
                "Cuauhtémoc",
                "Francisco Javier Mina",
                "Mariano Matamoros",
                "General José Silvestre Aramberri",
                "General Jerónimo Treviño",
                "Padre Mier",
                "General Mariano Escobedo(Sur)",
                "General Mariano Escobedo(Norte)",
                "5 de Mayo",
                "Juan Ignacio Ramón(Ote)",
                "Ignacio Allende",
                "Diego de Montemayor",
                "Capitán Emilio Carranza",
                "Isaac Garza",
                "Prof. Serafín Peña",
                "Valentín Gómez Farías",
                "General Francisco Naranjo",
                "Hermenegildo Galeana",
                "Ignacio Zaragoza",
                "América",
                "15 de Mayo",
                "General Juan Zuazua",
                "Venustiano Carranza",
                "Vicente Guerrero",
                "José Ma. Arteaga",
                "Luis Carvajal y de la Cueva",
                "Avenida Benito Juárez",
                "Avenida José Ma. Pino Suárez",
                "Calzada Francisco I. Madero",
                "Modesto Arreola",
                "Jalisco, Querétaro, 16 de Septiembre(calles de la Colonia Independencia)",
                "Hilario Martínez",
                "General Julián Villagrán",
                "Porfirio Díaz",
                "Cristobal Colón",
                "Reforma",
                "Guillermo Prieto",
                "Dr. José María Coss(Dr. Coss)",
                "Nicolás Bravo",
                "Ignacio López Rayón",
                "Juan Aldama",
                "Calzada Victoria",
                "Paras",
                "Álvarez",
                "José Garibaldi",
                "Corregidora",
                "José Mariano Jiménez",
                "Alejandro de Humboldt",
                "Carlos Salazar",
                "General Santiago Tapia",
                "Del Demócrata Manuel María de Llano",
                "General Albino Espinosa",
                "General Miguel Nieto",
                "General Ramón Corona",
                "General Ignacio L. Vallarta",
                "General Ruperto Martínez",
                "General Santos Degollado",
                "Víctor Hugo",
                "General Juan N. Méndez",
                "México(Colonia Obispado)",
                "Adolfo Ruiz Cortines",
                "General Félix Uresti Gómez",
                "General Julián Villarreal",
                "General Álvaro Obregón",
                "20 de Noviembre",
                "20 de Noviembre",
                "José Trinidad Villagómez",
                " Prolongación Silvestre Aramberri",
                "Joaquín Garza Leal",
                "Calzada Bernardo Reyes",
                "General Jesús González Ortega",
                "General Mariano Arista",
                "Avenida Constitución",
                "Camino de San Agustin",
                "Castelar",
                "León Guzmán",
                "Héroes del 47",
                "Rafael Platón Sánchez",
                "Washington",
                "General Manuel Doblado",
                "Martín de Zavala",
                "General Felipe Santiago Xicoténcatl",
                "Tomás Alva Edison",
                "General Pedro Martínez",
                "Padre Mier Poniente",
                "Francisco Zarco",
                "Licenciado Verdad",
                "Avenida José Eleuterio González “Gonzalitos”",
                "Capitán Lorenzo Aguilar",
                "Colegio Civil",
                "Jesús Dionisio González",
                "Héroes de Nacozari",
                "Magallanes",
                "Democracia",
                "Marco Polo",
                "Vasco de Gama",
                "Magnolia",
                "San Francisco(Colonia Moderna)",
                "Diez Gutiérrez",
                "Bruselas",
                "Lisboa",
                "Paris",
                "General Francisco Naranjo",
                "Del Fortin",
                "Aquiles Serdán",
                "Avenida Simón Bolívar",
                "Constantino de Tarnava",
                "Jordán"
        };

        private static IList<string> motherNames = new List<string>()
        {
            "DEL CASTILLO",
            "BENITES",
            "SEBASTIANI",
            "AGUILAR",
            "AGUILAR",
            "AGUIRRE",
            "ALCAS",
            "ALDAZ",
            "ALIAGA",
            "ALVARO",
            "ARANGO",
            "ARBILDO",
            "ARCOS",
            "ATAYUPANQUI",
            "AUQUI",
            "BALDEON",
            "BALVIN",
            "BARRA",
            "BAUTISTA",
            "BENANCIO",
            "BUSTOS",
            "CABALLERO",
            "CABRERA",
            "CACHIQUE",
            "CALDERON",
            "CAMPOS",
            "CARBAJAL",
            "CAREAJANO",
            "CARRERA",
            "CARRERA",
            "CARRERA",
            "CASTILLO",
            "CASTILLO",
            "CAYLLAHUA",
            "CHOQUECAHUA",
            "COMUN",
            "CORDOVA",
            "CUEVA",
            "CUEVA",
            "CUEVA",
            "ESCALANTE",
            "ESPINOZA",
            "FACUNDO",
            "FARFAN",
            "FLORES",
            "FUENTES",
            "GARAMENDI",
            "GARAY",
            "GONZALES",
            "GUTARRA",
            "GUTIERREZ",
            "HINOSTROZA",
            "HUAMAN",
            "HUAMAN",
            "HUARCAYA",
            "HUAYHUARIMA",
            "LARRAÑAGA",
            "LLOCLLA",
            "LOPEZ",
            "MAGUIÑA",
            "MAMANI",
            "MARTINEZ",
            "MARTINEZ",
            "MEJIA",
            "MORENO",
            "MUCHA",
            "MUÑOZ",
            "NUÑEZ",
            "OSCO",
            "PAREDES",
            "PEREA",
            "QUISPE",
            "QUISPE",
            "RAMIREZ",
            "RAMIREZ",
            "RIOS",
            "RIOS",
            "RIVERA",
            "RIVERA",
            "RODAS",
            "ROJAS",
            "SALCEDO",
            "SALDAÑA",
            "SANCHEZ",
            "SOTO",
            "SUPO",
            "TENAZOA",
            "TOMAS",
            "TREBEJO",
            "TRUJILLO",
            "UCHARIMA",
            "VALDERA",
            "VALLES",
            "VARGAS",
            "VILCHEZ",
            "YANA",
            "YAURI",
            "ZAMBRANO",
            "ZARATE"
        };

        private static IList<string> lastNames = new List<string>()
        {
            "PEREZ",
            "DEL SOLAR",
            "CEPEDA",
            "CISNEROS",
            "RUIZ",
            "PINTO",
            "ALVARADO",
            "ZURITA",
            "VILCHEZ",
            "ESPINOZA",
            "MONTOYA",
            "VASQUEZ",
            "HUAMAN",
            "CONZA",
            "RUIZ",
            "TOLEDO",
            "SALAZAR",
            "SALAS",
            "ALVAREZ",
            "TOLENTINO",
            "MAYTA",
            "BULEJE",
            "CRIOLLO",
            "PIZANGO",
            "GONZA",
            "ROJAS",
            "GONZALES",
            "MACEDO",
            "DOROTEO",
            "MORALES",
            "MORALES",
            "BACON",
            "GONZALES",
            "ORTIZ",
            "BAUTISTA",
            "CASTILLO",
            "ALVARADO",
            "VILCHEZ",
            "VILCHEZ",
            "VILLANUEVA",
            "HUAYAS",
            "YANAC",
            "HUAMAN",
            "VALVERDE",
            "HUARANCCA",
            "JIMENEZ",
            "TORRES",
            "DAVAN",
            "TALAVERANO",
            "IZAGUIRRE",
            "TICLIAHUANCA",
            "MORENO",
            "AGUILAR",
            "AGUILAR",
            "LOPEZ",
            "MORENO",
            "RODRIGUEZ",
            "CRIOLLO",
            "AUCCASI",
            "CCAHUANA",
            "ROMERO",
            "HURTADO",
            "HURTADO",
            "QUISPE",
            "HUAYTALLA",
            "VILCHEZ",
            "QUISPE",
            "VILLANUEVA",
            "DELGADO",
            "PEREZ",
            "TEVES",
            "FERNANDEZ",
            "LUYO",
            "YLLANES",
            "YLLANES",
            "NUNTA",
            "NUNTA",
            "JOEL",
            "PADILLA",
            "FRACCHIA",
            "GARCIA",
            "LAURA",
            "PAIMA",
            "MINAYA",
            "HINOJOSA"
        };

        private static IList<string> femenineNames = new List<string>()
        {
            "SONIA",
            "SANDRA",
            "ALICIA",
            "MARGARITA",
            "SUSANA",
            "MARINA",
            "YOLANDA",
            "MARIA JOSEFA",
            "NATALIA",
            "MARIA ROSARIO",
            "INMACULADA",
            "ESTHER",
            "EVA",
            "MARIA MERCEDES",
            "ANGELES",
            "ANA ISABEL",
            "NOELIA",
            "VERONICA",
            "CLAUDIA",
            "AMPARO",
            "MARIA ROSA",
            "MARIA VICTORIA",
            "CAROLINA",
            "MARIA CONCEPCION",
            "EVA MARIA",
            "LORENA",
            "NEREA",
            "VICTORIA",
            "ANA BELEN",
            "CATALINA",
            "CARLA",
            "MARIA ELENA",
            "MIRIAM",
            "CONSUELO",
            "MARIA ANTONIA",
            "INES",
            "SOFIA",
            "EMILIA",
            "LUISA",
            "MARIA NIEVES",
            "LIDIA",
            "GLORIA",
            "AURORA",
            "OLGA",
            "CELIA",
            "ESPERANZA",
            "JOSEFINA",
            "MILAGROS",
            "MARIA SOLEDAD",
            "MARIA CRISTINA",
            "VIRGINIA"
        };

        private static IList<string> masculineNames = new List<string>() 
        {
            "VICTOR",
            "ROBERTO",
            "JAIME",
            "FRANCISCO JOSE",
            "IGNACIO",
            "MARIO",
            "ALFONSO",
            "SALVADOR",
            "RICARDO",
            "JORDI",
            "MARCOS",
            "EMILIO",
            "JULIAN",
            "JULIO",
            "GUILLERMO",
            "TOMAS",
            "GABRIEL",
            "AGUSTIN",
            "JOSE MIGUEL",
            "FELIX",
            "JOSE RAMON",
            "GONZALO",
            "MARC",
            "MOHAMED",
            "JOAN",
            "HUGO",
            "ISMAEL",
            "CRISTIAN",
            "NICOLAS",
            "MARIANO",
            "JOSEP",
            "DOMINGO",
            "SAMUEL",
            "JUAN FRANCISCO",
            "ALFREDO",
            "SEBASTIAN",
            "AITOR",
            "JOSE CARLOS",
            "MARTIN",
            "FELIPE",
            "CESAR",
            "HECTOR",
            "JOSE ANGEL",
            "JOSE IGNACIO",
            "VICTOR MANUEL",
            "GREGORIO",
            "LUIS MIGUEL",
            "IKER",
            "JOSE FRANCISCO",
            "JUAN LUIS",
            "ALBERT",
            "LORENZO",
            "ALEX",
            "XAVIER",
            "RODRIGO"
        };
        #endregion

        static void Main(string[] args)
        {
            for (int i = 1986; i <= 1995; i++)
            {
                years.Add(i);
            }

            for (int i = 1; i <= 12; i++)
            {
                months.Add(i);
            }

            for (int i = 1; i <= 28; i++)
            {
                days.Add(i);
            }

            //GenerateFakeCustomers(20);
            GenerateFakeSimulations(200);
            //GenerateCommercialAssistants(50);
            

            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }

        #region Util methods
        public static string GenerateEmail(string firstName, string lastName)
        {
            string domain = domains[randomizer.Next(0, domains.Count)];
            return string.Format("{0}.{1}{2}@{3}", firstName.Replace(" ", string.Empty).ToLower(), lastName.Replace(" ", string.Empty).ToLower(), randomizer.Next(0, 200), domain);
        }

        public static string GenerateUserName(string firstName, string lastName)
        {
            return string.Format("{0}.{1}.{2}", firstName.Replace(" ", string.Empty).ToLower(), lastName.Replace(" ", string.Empty).ToLower(), randomizer.Next(0, 200));
        }

        public static string GetRandomMasculine()
        {
            var randNumber = (int)randomizer.Next(0, masculineNames.Count);
            return masculineNames[randNumber];
        }

        public static string GetRandomFemenine()
        {
            var randNumber = (int)randomizer.Next(0, femenineNames.Count);
            return femenineNames[randNumber];
        }

        public static string GetRandomMothersName()
        {
            var randNumber = (int)randomizer.Next(0, motherNames.Count);
            return motherNames[randNumber];
        }

        public static string GetRandomLastName()
        {
            var randNumber = (int)randomizer.Next(0, lastNames.Count);
            return lastNames[randNumber];
        }

        public static int GetRandomCity()
        {
            var randNumber = (int)randomizer.Next(0, cities.Count);
            return cities[randNumber];
        }

        public static int GetRandomBloodType()
        {
            var randNumber = (int)randomizer.Next(0, bloodTypes.Count);
            return bloodTypes[randNumber];
        }

        public static string GetRandomAddress()
        {
            var randNumber = (int)randomizer.Next(0, addresses.Count);
            return string.Format("{0} No. {1}", addresses[randNumber], randomizer.Next(1, 400));
        }

        public static string GetRandomAddress2()
        {
            var randNumber = (int)randomizer.Next(0, addresses2.Count);
            return addresses2[randNumber];
        }

        public static string GenerateRandomPhoneNumber()
        {
            string result = string.Empty;

            for (int i = 0; i < 10; i++)
            {
                result += randomizer.Next(0, 10).ToString();
            }

            return result;
        }

        public static string GenerateRFC(string firstName, string lastName, string mothersName, out DateTime birthDate)
        {
            int fullYear = years[randomizer.Next(0, years.Count)];
            string year = fullYear.ToString().Substring(2, 2);
            string month = months[randomizer.Next(0, months.Count)].ToString("D2");
            string day = days[randomizer.Next(0, days.Count)].ToString("D2");

            birthDate = new DateTime(Convert.ToInt32(fullYear), Convert.ToInt32(month), Convert.ToInt32(day));

            string safeLastName = lastName.Replace(" ", string.Empty);
            char lastLetter = safeLastName[randomizer.Next(0, safeLastName.Length)];

            return string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}", lastName[0], mothersName[0], firstName.Substring(0, 2), year, month, day, randomizer.Next(0, 10), lastLetter, randomizer.Next(0, 10));
        }

        public static void GenerateFakeCustomers(int numberOfItemsToGenerate = 100)
        {
            string gender = "F", firstName, lastName, mothersName, rfc;

            using (var repor = new CustomersRepository())
            {
                for (int i = 0; i < numberOfItemsToGenerate; i++)
                {
                    gender = randomizer.Next(0, 2) > 0 ? "M" : "F";

                    if (gender == "F")
                    {
                        firstName = GetRandomFemenine();
                    }
                    else
                    {
                        firstName = GetRandomMasculine();
                    }

                    DateTime birthDate = new DateTime();

                    lastName = GetRandomLastName();
                    mothersName = GetRandomMothersName();

                    rfc = GenerateRFC(firstName, lastName, mothersName, out birthDate);

                    Customer customer = new Customer
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        MothersName = mothersName,
                        CityID = GetRandomCity(),
                        RFC = rfc,
                        BirthDate = birthDate,
                        Gender = gender,
                        Email = GenerateEmail(firstName, lastName),
                        PhoneNumber = GenerateRandomPhoneNumber(),
                        Address1 = GetRandomAddress(),
                        Address2 = GetRandomAddress2(),
                        CellNumber = GenerateRandomPhoneNumber(),
                        BloodTypeID = GetRandomBloodType(),
                        Smoke = randomizer.Next(0, 2),
                        Drink = randomizer.Next(0, 2),
                        PracticeSports = randomizer.Next(0, 2),
                        StateID = 1
                    };

                    repor.Add(customer);

                    Console.WriteLine("Customer {0} {1} {2} has been created", customer.FirstName, customer.LastName, customer.MothersName);
                    Console.WriteLine("");
                }
            }
        }

        public static void GenerateCommercialAssistants(int numberOfItemsToGenerate = 10)
        {
            string gender = "F", firstName, lastName, mothersName;

            int roleId = Catalogs.GetRoles().First( r => r.Name == "comercial-assistant").RoleID;

            using (var repor = new UsersRepository())
            {
                for (int i = 0; i < numberOfItemsToGenerate; i++)
                {
                    gender = randomizer.Next(0, 2) > 0 ? "M" : "F";

                    if (gender == "F")
                    {
                        firstName = GetRandomFemenine();
                    }
                    else
                    {
                        firstName = GetRandomMasculine();
                    }

                    lastName = GetRandomLastName();
                    mothersName = GetRandomMothersName();

                    User customer = new User
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        MothersName = mothersName,
                        Password = "pass.word1",
                        RoleID = roleId,
                        UserName = GenerateUserName(firstName, lastName)
                    };

                    repor.Add(customer);

                    Console.WriteLine("Commercial assistant {0} {1} {2} has been created", customer.FirstName, customer.LastName, customer.MothersName);
                    Console.WriteLine("");
                }
            }
        }

        public static void GenerateFakeSimulations(int numberOfItemsToGenerate = 100)
        {
            double subTotal = 0;
            double discount = 0;

            var paymentTypes = Catalogs.GetPaymentTypes().ToList();
            var planTypes = Catalogs.GetPlanTypes().ToList();

            using (var repor = new SimulationsRepository())
            {
                using (var customersRepo = new CustomersRepository())
                {
                    using (var usersRepo = new UsersRepository())
                    {

                        for (int i = 0; i < numberOfItemsToGenerate; i++)
                        {

                            Customer customer = customersRepo.GetRandomCustomer();

                            int age = DateTime.Now.Year - customer.BirthDate.Year;

                            PaymentType paymentType = paymentTypes.ElementAt(randomizer.Next(0, paymentTypes.Count));
                            PlanType planType = planTypes.ElementAt(randomizer.Next(0, planTypes.Count));

                            subTotal = CalculateSubTotal(age, customer.Gender, planType.PlanTypeID);
                            discount = GetDiscount(subTotal, paymentType);

                            double total = subTotal - discount;

                            DateTime fakeToday = RandomDay();

                            repor.Add(customer.CustomerID, paymentType.PaymentTypeID, planType.PlanTypeID, GetNextFolioId(), fakeToday, usersRepo.GetRandomUserId(), discount, subTotal, total);

                            Console.WriteLine("Generated simulation for {0} with Plan Type: {1} and payment type : {2}", customer.FullName, planType.Title, paymentType.Title);
                            Console.WriteLine("");
                        }
                    }
                }
            }
        }

        private static double CalculateSubTotal(int age, string gender, int planTypeId)
        {
            double price = 0;

            using (var planTypesRepo = new PlanTypesRepository())
            {
                price = planTypesRepo.GetApplicableRule(planTypeId, age, gender);
            }

            return price;
        }

        private static DateTime RandomDay()
        {
            int range = (DateTime.Today - start).Days;
            return start.AddDays(randomizer.Next(range));
        }

        private static double GetDiscount(double subTotal, PaymentType paymentType)
        {
            return subTotal * (paymentType.DiscountPercentage / 100);
        }

        private static int GetNextFolioId()
        {
            Folio folio = new Folio();

            using (var folioRepo = new FoliosRepository())
            {
                folio = folioRepo.GetNextFolio();
            }

            return folio.FolioID;
        }

        #endregion
    }
}
