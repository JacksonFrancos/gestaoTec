using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestaoTec.Domain.Entities
{
    internal class Equipment

    {

        public Guid EquipementID { get; set; }
        public string EquipName { get; set; }
        public string EquipType { get; set; }

        public string EquipmentModel  { get; set; }
        public string EquipmentMark { get; set; }
        public int EquipSerie { get; set; }


        // Metodo para garantir que o objeto sempre estará em um estado válido
        // metodo para criar o objeto com o modelo exato que deve ser criado
        public static Equipment Create( string equipName, string equipType, string equipmentModel, string equipmentMark,int equipSerie, Guid equipementID)
        {
            if (string.IsNullOrWhiteSpace(equipName))
            {
                throw new ArgumentException("O nome do equipamento não pode ser nulo", nameof(equipName));
            }
            return new Equipment
            {
                EquipementID = equipementID,
                EquipName = equipName,
                EquipType = equipType,
                EquipmentModel = equipmentModel,
                EquipmentMark = equipmentMark,
                EquipSerie = equipSerie
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
