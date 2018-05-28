using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kloud.Models;
using Newtonsoft.Json;

namespace Kloud.BusinessLogic.Business
{
    public class Replica
    {
        public string ReplicaService()
        {
            var data = new List<Owner>
            {
                new Owner
                {
                    Name = "Bradley",
                    Cars = new List<Car>
                    {
                        new Car
                        {
                            Brand = "MG",
                            Colour = "Blue"
                        }
                    }
                },
                new Owner
                {
                    Name = "Demetrios",
                    Cars = new List<Car>
                    {
                        new Car
                        {
                            Brand = "Toyota",
                            Colour = "Green"
                        },
                        new Car
                        {
                            Brand = "Holden",
                            Colour = "Blue"
                        }
                    }
                },
                new Owner
                {
                    Name = "Brooke",
                    Cars = new List<Car>
                    {
                        new Car
                        {
                            Brand = "Holden",
                            Colour = ""
                        }
                    }
                },
                new Owner
                {
                    Name = "Kristin",
                    Cars = new List<Car>
                    {
                        new Car
                        {
                            Brand = "Toyota",
                            Colour = "Blue"
                        },
                        new Car
                        {
                            Brand = "Mercedes",
                            Colour = "Green"
                        },
                        new Car
                        {
                            Brand = "Mercedes",
                            Colour = "Yellow"
                        }
                    }
                },
                new Owner
                {
                    Name = "Andre",
                    Cars = new List<Car>
                    {
                        new Car
                        {
                            Brand = "BMW",
                            Colour = "Green"
                        },
                        new Car
                        {
                            Brand = "Holden",
                            Colour = "Black"
                        }
                    }
                },
                new Owner
                {
                    Cars = new List<Car>
                    {
                        new Car
                        {
                            Brand = "Mercedes",
                            Colour = "Blue"
                        }
                    }
                },
                new Owner
                {
                    Name = "",
                    Cars = new List<Car>
                    {
                        new Car
                        {
                            Brand = "Mercedes",
                            Colour = "Red"
                        },
                        new Car
                        {
                            Brand = "Mercedes",
                            Colour = "Blue"
                        }
                    }
                },
                new Owner
                {
                    Name = "Matilda",
                    Cars = new List<Car>
                    {
                        new Car
                        {
                            Brand = "Holden"
                        },
                        new Car
                        {
                            Brand = "BMW",
                            Colour = "Black"
                        }
                    }
                },
                new Owner
                {
                    Name = "Iva",
                    Cars = new List<Car>
                    {
                        new Car
                        {
                            Brand = "Toyota",
                            Colour = "Purple"
                        }
                    }
                },
                new Owner
                {
                    Cars = new List<Car>
                    {
                        new Car
                        {
                            Brand = "Toyota",
                            Colour = "Blue"
                        },
                        new Car
                        {
                            Brand = "Mercedes",
                            Colour = "Blue"
                        }
                    }
                }
            };
            return JsonConvert.SerializeObject(data);
        }
    }
}
