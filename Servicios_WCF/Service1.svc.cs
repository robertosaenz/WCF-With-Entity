using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Servicios_WCF.Class;
using Servicios_WCF.Models;

namespace Servicios_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        int IService1.EliminarMedicamento(int iidMedicamento)
        {
            int response = 0;
            try
            {
                using (var bd = new MedicoEntities())
                {
                    Medicamento oMedicamento = bd.Medicamentoes.Where(p => p.IIDMEDICAMENTO == iidMedicamento).First();
                    oMedicamento.BHABILITADO = 0;
                    bd.SaveChanges();
                    response = 1;
                }
            }
            catch(Exception ex)
            {
                response = 0;
            }
            return response;
        }

        List<FormaFarmaceutica_class> IService1.ListarFormaFarmaceutica()
        {
            List<FormaFarmaceutica_class> ListaFormaFarmaceutica = new List<FormaFarmaceutica_class>();
            try
            {
                using (var bd = new MedicoEntities())
                {
                    ListaFormaFarmaceutica = bd.FormaFarmaceuticas.Where(p=>p.BHABILITADO==1)
                    .Select(p => new FormaFarmaceutica_class
                    {
                        IIDFORMAFARMACEUTICA = p.IIDFORMAFARMACEUTICA,
                        nombreFormaFarmaceutica = p.NOMBRE
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                ListaFormaFarmaceutica = null;
            }
            return ListaFormaFarmaceutica;
        }

        List<Medicamento_class> IService1.ListarMedicamentos()
        {
            List<Medicamento_class> ListaMedicamentos = new List<Medicamento_class>();
            try
            {
                using (var bd = new MedicoEntities())
                {
                    ListaMedicamentos = (from medicamento in bd.Medicamentoes
                                         join FormaFarmaceutica in bd.FormaFarmaceuticas
                                         on medicamento.IIDFORMAFARMACEUTICA equals FormaFarmaceutica.IIDFORMAFARMACEUTICA
                                         select new Medicamento_class
                                         {
                                             IIDMEDICAMENTO = medicamento.IIDMEDICAMENTO,
                                             NOMBRE = medicamento.NOMBRE,
                                             PRECIO = (decimal)medicamento.PRECIO,
                                             NOMBREFORMAFARMACEUTICA = FormaFarmaceutica.NOMBRE,
                                             CONCENTRACION = medicamento.CONCENTRACION,
                                             PRESENTACION = medicamento.PRESENTACION,
                                             STOCK = (int)medicamento.STOCK,
                                             BHABILITADO = (int)medicamento.BHABILITADO
                                          

                                         }).ToList();
                }

            }
            catch (Exception ex)
            {
                ListaMedicamentos = null;
            }

            return ListaMedicamentos;
        }

        Medicamento_class IService1.RecuperarMedicamento(int iidMedicamento)
        {
            Medicamento_class oMedicamento_class = new Medicamento_class();
            try
            {
                using (var bd = new MedicoEntities())
                {
                    Medicamento oMedicamento = bd.Medicamentoes.Where(p => p.IIDMEDICAMENTO == iidMedicamento).First();
                    oMedicamento_class.IIDMEDICAMENTO = oMedicamento.IIDMEDICAMENTO;
                    oMedicamento_class.IIDFORMAFARMACEUTICA = (int)oMedicamento.IIDFORMAFARMACEUTICA;

                    oMedicamento_class.NOMBRE = oMedicamento.NOMBRE;
                    oMedicamento_class.PRECIO = (decimal)oMedicamento.PRECIO;
                    oMedicamento_class.STOCK = (int)oMedicamento.STOCK;
                    oMedicamento_class.CONCENTRACION= oMedicamento.CONCENTRACION;
                    oMedicamento_class.PRESENTACION = oMedicamento.PRESENTACION;
                }
            }
            catch (Exception ex)
            {
                oMedicamento_class = null;
            }
            return oMedicamento_class;
        }

        int IService1.registraryactualizarmedicamentos(Medicamento_class oMedicamento_class)
        {
            int response = 0;
            try
            {
                using (var bd = new MedicoEntities())
                {
                    //REGISTRAR
                    if (oMedicamento_class.IIDMEDICAMENTO == 0)
                    {
                        Medicamento oMedicamento = new Medicamento();
                        oMedicamento.IIDMEDICAMENTO = oMedicamento_class.IIDMEDICAMENTO;

                        oMedicamento.NOMBRE = oMedicamento_class.NOMBRE;
                        oMedicamento.PRECIO = oMedicamento_class.PRECIO;
                        oMedicamento.STOCK = oMedicamento_class.STOCK;
                        oMedicamento.IIDFORMAFARMACEUTICA = oMedicamento_class.IIDFORMAFARMACEUTICA;
                        oMedicamento.CONCENTRACION = oMedicamento_class.CONCENTRACION;
                        oMedicamento.PRESENTACION = oMedicamento_class.PRESENTACION;
                        oMedicamento.BHABILITADO = 1;

                        bd.Medicamentoes.Add(oMedicamento);
                        bd.SaveChanges();
                        response = 1;
                    }
                    else
                    {
                        Medicamento oMedicamento = bd.Medicamentoes.Where(p => p.IIDMEDICAMENTO == oMedicamento_class.IIDMEDICAMENTO).First();
                        oMedicamento.IIDMEDICAMENTO = oMedicamento_class.IIDMEDICAMENTO;
                        oMedicamento.IIDFORMAFARMACEUTICA = oMedicamento_class.IIDFORMAFARMACEUTICA ;
                        oMedicamento.NOMBRE = oMedicamento_class.NOMBRE;
                        oMedicamento.PRECIO = oMedicamento_class.PRECIO;
                        oMedicamento.STOCK = oMedicamento_class.STOCK;
                        oMedicamento.CONCENTRACION = oMedicamento_class.CONCENTRACION;
                        oMedicamento.PRESENTACION = oMedicamento_class.PRESENTACION;
                        bd.SaveChanges();
                        response = 1;
                    }
                }
            }
            catch
            {
                response = 0;
            }
            return response;
        }
    }
}
