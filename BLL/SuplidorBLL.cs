using Microsoft.EntityFrameworkCore;
using RegistroPedidosDetalle.DAL;
using RegistroPedidosDetalle.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RegistroPedidosDetalle.BLL
{
    public class SuplidorBLL
    {
        public static bool Guardar(Suplidores suplidores)
        {
            bool paso = false;
            Contexto db = new Contexto();


            try
            {
                if (db.suplidores.Add(suplidores) != null)
                    paso = db.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;

        }


        public static bool Modificar(Suplidores suplidores)
        {
            bool paso = false;
            Contexto db = new Contexto();


            try
            {

                db.Entry(suplidores).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);

            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }


        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = db.suplidores.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;

                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;

        }


        public static Suplidores Buscar(int id)
        {
            Suplidores suplidores = new Suplidores();
            Contexto db = new Contexto();

            try
            {
                suplidores = db.suplidores.Find(id);
            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                db.Dispose();
            }

            return suplidores;

        }

        public static List<Suplidores> GetList(Expression<Func<Suplidores, bool>> suplidores)
        {
            List<Suplidores> Lista = new List<Suplidores>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.suplidores.Where(suplidores).ToList();
            }

            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;

        }
    }
}
