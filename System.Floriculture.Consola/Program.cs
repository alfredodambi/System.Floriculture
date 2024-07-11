using System.Collections;
using System.Configuration;
using System.Floriculture.Application.Services;
using System.Floriculture.Domain.Interface;
using System.Floriculture.Domain.Models;
using System.Floriculture.Infrastruture.Repository;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace System.Floriculture.Consola
{
    internal class Program
    {
        int optionMenu = 0;
        //Inicialize Others Components Project
        public string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionDb"].ConnectionString;
        public IRepositoryClient _repositoryClient;
        public ServiceClient _serviceClient;

        public Program() 
        {
            InitialComponents();
        
        }

        void InitialComponents()
        {
            _repositoryClient = new RepositoryClient(_connectionString);
            _serviceClient = new ServiceClient(_repositoryClient);
        }

        static async Task Main(string[] args)
        {
            Program program = new Program();

            //System Name
            Console.WriteLine("** System Floriculture **");
            Console.ReadLine();

            //Main Menu
           await program.MainSystemAsync();
        }


        public async Task MainSystemAsync()
        {

            do
            {
                Console.WriteLine("1- Clients ");
                Console.WriteLine("2- Products ");
                Console.WriteLine("3- Purchase");
                Console.WriteLine("4- Leave The System");

                if (!int.TryParse(Console.ReadLine(), out optionMenu))
                {
                    Console.WriteLine("Ivalid Option. Please enter a number betwen 1 and 4");
                    continue;
                }
                switch (optionMenu)
                {
                    case 1:
                        //Clients main 
                        await Clients();

                        break;

                    case 2:
                        //Products main
                        await Products();
                        break;

                    case 3:

                        break;

                    default:

                        Console.WriteLine("Press any key to leave the system");
                        Console.ReadLine();
                        break;
                }

            } while (optionMenu != 4);
        }

        /// <summary>
        /// Clients Crud menu
        /// </summary>
        public async Task Clients()
        {
            int clientOption = 0;


            do
            {
                Console.WriteLine("## Client Main ##");
                Console.WriteLine("-+--+-+-+-+--+-+----+-+-+-+-+-+-+-+-+-+-+--++-");
                Console.WriteLine("1 - Add ");
                Console.WriteLine("2 - Update");
                Console.WriteLine("3 - List");
                Console.WriteLine("4 - Delete");
                Console.WriteLine("5 - Leave Client Main");
                Console.WriteLine("-+--+-+-+-+--+-+----+-+-+-+-+-+-+-+-+-+-+--++-");

                //Option client menu selected
                if(!int.TryParse(Console.ReadLine(), out clientOption))
                {
                    Console.WriteLine("Invalid option enter. Please choose a number betwen 1 to 5");
                    continue;
                }


                switch (clientOption)
                {
                    case 1:
                        //Add new client method
                        await AddClient();
                        break;

                    case 2:
                        //Upadate a client method
                        await UpdateClient();
                        break;

                    case 3:
                        //List of clients
                        await ListClient();
                        break;

                    case 4:
                        //Remove a client
                        await DeleteClient();
                        break;

                    default:

                        Console.WriteLine("Press any key to leave the client main");
                        Console.ReadLine();
                        break;
                }


            } while (clientOption != 5);

        }
        /// <summary>
        /// Add new Client
        /// </summary>
        /// <returns>A client</returns>
        public async Task AddClient()
        {
            Client client = new Client();
            Console.WriteLine("## Create a new Client ##");
            Console.WriteLine("******************************************");

            Console.WriteLine("Type the Client Bi number: ");
            client.Bi = Console.ReadLine();

            Console.WriteLine("Type the Client First and Last Name: ");
            client.Name = Console.ReadLine();

            Console.WriteLine("Type the Client Phone number: ");
            client.Phone = Console.ReadLine();

            Console.WriteLine("Type the Client Address: ");
            client.Address = Console.ReadLine();

            try
            {
                await _serviceClient.CreateClientAsync(client);
                Console.WriteLine("Client create Successfull");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error to create new client." + ex.ToString());
            }
            Console.WriteLine("******************************************");
        }
        /// <summary>
        /// Update a Client
        /// </summary>
        /// <returns></returns>
        public async Task UpdateClient()
        {
            Console.WriteLine("## Update a Client ##");
            Console.WriteLine("******************************************");

            Console.WriteLine("Type the Client Id that you what to update: ");

            if(!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid id. Enter a valid Id");
                return;
            }

            var clientUpdate = await _serviceClient.GetClientByIdAsync(id);

            if (clientUpdate == null)
            {
                Console.WriteLine("Client not found.");
                return;
            }
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Client found : " + clientUpdate.Name);

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Type the new Client Bi: ");
            clientUpdate.Bi = Console.ReadLine();

            Console.WriteLine("Type the new Client Full Name : ");
            clientUpdate.Name = Console.ReadLine();

            Console.WriteLine("Type the new client Phone Number: ");
            clientUpdate.Phone = Console.ReadLine();

            Console.WriteLine("Type the new Client Address: ");
            clientUpdate.Address = Console.ReadLine();

            try
            {
                await _serviceClient.UpdateClientAsync(clientUpdate);
                Console.WriteLine("Client data update successfull");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error to update the client. " + ex.Message);
            }
            Console.ReadLine();
            Console.WriteLine("******************************************");
        }
        /// <summary>
        /// View a list of client
        /// </summary>
        /// <returns></returns>
        public async Task ListClient()
        {
            Console.WriteLine("## List Client ##");
            Console.WriteLine("******************************************");

            var clients = await _serviceClient.GetAllClientsAsync();

            foreach (var client1 in clients)
            {
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine($" Id : {client1.Id} | Bi: {client1.Bi} |Name:{client1.Name} |Phone: {client1.Phone} | Address: {client1.Address} ");
                Console.WriteLine("-------------------------------------------------------");
            }
            Console.WriteLine("******************************************");
            Console.ReadLine();
        }
        /// <summary>
        /// Dele a client
        /// </summary>
        /// <returns></returns>
        public async Task DeleteClient()
        {
            Console.WriteLine("## Delete a Client ##");
            Console.WriteLine("******************************************");

            Console.WriteLine("Type the Id of The client: ");

            if(!int.TryParse(Console.ReadLine(), out int Id)) 
            {
                Console.WriteLine("Invalid Id");
                return;
            }

            var clientToDelete = await _serviceClient.GetClientByIdAsync(Id);

            if(clientToDelete == null)
            {
                Console.WriteLine("Client not found");
                return;
            }

            Console.WriteLine("The Client Name: " + clientToDelete.Name);
            Console.WriteLine("******************************************");

            try
            {
                await _serviceClient.DeleteClientAsync(clientToDelete.Id);
                Console.WriteLine("Client Deleted Successul");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error to Delete Client {ex.Message}");
            }
            Console.WriteLine("******************************************");
            Console.ReadLine();
        }


        /// <summary>
        /// Product main
        /// </summary>
        /// <returns></returns>
        public async Task Products()
        {
            int productOption = 0;

            do
            {
                Console.WriteLine("-- Product Main menu --");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("1- Add");
                Console.WriteLine("2- Update");
                Console.WriteLine("3- List");
                Console.WriteLine("4- Delet");
                Console.WriteLine("5- Leave product menu");

                if (!int.TryParse(Console.ReadLine(), out productOption))
                {
                    Console.WriteLine("Invalid enter option menu. Enter a value betwen 1 and 5");
                    continue;
                }

                switch(productOption)
                {
                    case 1:

                        break;

                    case 2:

                        break;

                    case 3:

                        break;

                    case 4:

                        break;

                    default:

                        Console.WriteLine("Leaving the product main...");
                        Console.ReadLine();
                        break;

                }


            } while (productOption != 5);
        }
     
    }
}
