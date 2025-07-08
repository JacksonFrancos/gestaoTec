using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestaoTec.Domain.Enums;

namespace gestaoTec.Domain.Entities
{
    public class ServiceOrder
    {
        public  required string  ProblemDescription { get; set; }
        public DateTime InitialData { get; set; } = DateTime.Now;

        public OsStatusEnum OSStatus { get; set; }

        public Guid ServiceOrderID { get; set; }

        public required string Observation { get; set; }

        public DateTime ConcluidData { get; set; } = DateTime.Now;

        public required  Client Client { get; set; }
        public required Equipment Equipment { get; set; }



        public static ServiceOrder Create(string problemDescription, OsStatusEnum oSStatus, Guid serviceOrderID, string observation, Client client, Equipment equipment)
        {
            {
                if (string.IsNullOrWhiteSpace(problemDescription))
                {
                    throw new ArgumentException("A descrição do problema não pode ser nula", nameof(problemDescription));
                }
                return new ServiceOrder
                {
                    ProblemDescription = problemDescription,
                    OSStatus = oSStatus,
                    Observation = observation,
                    ServiceOrderID = serviceOrderID,
                    InitialData = DateTime.Now,
                    ConcluidData = DateTime.Now,
                    Client = client,
                    Equipment = equipment   

                };
            }
        }

        public void Update(OsStatusEnum oSStatus)
        {
            OSStatus = oSStatus;
        }

    }
}
