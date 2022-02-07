using System;
using Tarea3LabRegistros.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Tarea3LabRegistros.BLL
{
    public class CarrerasBLL
    {

        public static bool Existe(int carreraId)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Carreras.Any(l => l.CarreraId == carreraId);
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

        public static bool Guardar(Carreras carreras)
        {
            if (!Existe(carreras.CarreraId))
                return Insertar(carreras);
            else
                return Modificar(carreras);

        }

        private static bool Insertar(Carreras carrera)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
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
            Contexto contexto = new Contexto();
            bool paso = false;
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

        public static bool Eliminar(int carreraId)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                var carrera = contexto.Carreras.Find(carreraId);
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

        public static Carreras? Buscar(int carreraId)
        {
            Contexto contexto = new Contexto();
            Carreras? carrera;
            try
            {
                carrera = contexto.Carreras.Find(carreraId);
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

        public static List<Carreras> GetList(Expression<Func<Carreras, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Carreras> lista = new List<Carreras>();
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