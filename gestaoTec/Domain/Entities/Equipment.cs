using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestaoTec.Domain.Entities
{
    public class Equipment
    {
        public Guid EquipmentID { get; set; }
        public required string EquipName { get; set; }
        public required string EquipType { get; set; }

        public string? EquipmentModel  { get; set; }
        public string? EquipmentMark { get; set; }
        public int EquipSerie { get; set; }
        public Guid ClientId { get; set; }

        public  required Client Client { get; set; }
        public ICollection<ServiceOrder>? ServiceOrders { get; set; } = new List<ServiceOrder>();


        // Metodo para garantir que o objeto sempre estará em um estado válido : invariantes
        // metodo para criar o objeto com o modelo exato que deve ser criado : factory method
        public static Equipment Create( string equipName, string equipType, string equipmentModel, string equipmentMark,int equipSerie, Guid equipmentid, Client client)
        {
            if (string.IsNullOrWhiteSpace(equipName))
            {
                throw new ArgumentException("O nome do equipamento não pode ser nulo", nameof(equipName));
            }
            return new Equipment
            {
                EquipmentID = equipmentid,
                EquipName = equipName,
                EquipType = equipType,
                EquipmentModel = equipmentModel,
                EquipmentMark = equipmentMark,
                EquipSerie = equipSerie,
                Client = client

            };
        }


        public void Update(string equipName, string equipType, string equipmentModel, string equipmentMark, int equipSerie)
        {
            if (string.IsNullOrWhiteSpace(equipName))
            {
                throw new ArgumentException("O nome do equipamento não pode ser nulo", nameof(equipName));
            }
            EquipName = equipName;
            EquipType = equipType;
            EquipmentModel = equipmentModel;
            EquipmentMark = equipmentMark;
            EquipSerie = equipSerie;
        }
    }
}
