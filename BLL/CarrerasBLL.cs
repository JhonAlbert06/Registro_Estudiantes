using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using RegistroCarreras.DAL;
using RegistroCarreras.Entidades;

namespace RegistroCarreras.BLL
{
    public class CarrerasBLL
    {
        public static bool Guardar(Carreras carrera)
        {
            if (!Existe(carrera.CarreraID))
                return Insertar(carrera);
            else
                return Modificar(carrera);
        }

        private static bool Insertar(Carreras carrera)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Carreras.Add(carrera);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        private static bool Modificar(Carreras carrera)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(carrera).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var carrera = contexto.Carreras.Find(id);

                if (carrera != null)
                {
                    contexto.Carreras.Remove(carrera);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Carreras Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Carreras carrera;

            try
            {
                carrera = contexto.Carreras.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            
            return carrera;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Carreras.Any(e => e.CarreraID == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static List<Carreras> GetList(Expression<Func<Carreras, bool>> criterio)
        {
            List<Carreras> lista = new List<Carreras>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Carreras.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }

    }
}