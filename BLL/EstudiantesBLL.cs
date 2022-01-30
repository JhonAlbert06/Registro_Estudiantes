using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using RegistroCarreras.DAL;
using RegistroCarreras.Entidades;

namespace RegistroCarreras.BLL
{
    public class EstudiantesBLL
    {
        public static bool Guardar(Estudiantes estudiante)
        {
            if(!Existe(estudiante.EstudiantesID))
                return Insertar(estudiante);
            else
                return Modificar(estudiante);
        }

        private static bool Insertar(Estudiantes estudiante)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Estudiantes.Add(estudiante);
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

        private static bool Modificar(Estudiantes estudiante)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(estudiante).State = EntityState.Modified;
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
                var estudiante = contexto.Estudiantes.Find(id);

                if (estudiante != null)
                {
                    contexto.Estudiantes.Remove(estudiante);
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

        public static Estudiantes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Estudiantes estudiante;

            try
            {
                estudiante = contexto.Estudiantes.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return estudiante;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Estudiantes.Any(e => e.EstudiantesID == id);
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

        public static List<Estudiantes> GetList(Expression<Func<Estudiantes, bool>> criterio)
        {
            List<Estudiantes> lista = new List<Estudiantes>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Estudiantes.Where(criterio).ToList();
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