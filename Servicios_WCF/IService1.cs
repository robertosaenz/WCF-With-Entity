using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Servicios_WCF.Class;

namespace Servicios_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        // LISTAR MEDICAMENTOS
        [OperationContract] // EXPONER METODOS
        List<Medicamento_class> ListarMedicamentos();

        // LISTAR FORMA FARMACEUTICA
        [OperationContract]
        List<FormaFarmaceutica_class> ListarFormaFarmaceutica();

        // RECUPERAR MEDICAMENTO
        [OperationContract]
        Medicamento_class RecuperarMedicamento(int iidMedicamento);

        // AGREGAR Y EDITAR MEDICAMENTO
        [OperationContract]
        int registraryactualizarmedicamentos(Medicamento_class oMedicamento_class);// DEVOLVER UN ENTERO Y RECIBIR UN OBJETO

        // ELIMINAR MEDICAMENT
        [OperationContract]
        int EliminarMedicamento(int iidMedicamento);

    }


    
}
