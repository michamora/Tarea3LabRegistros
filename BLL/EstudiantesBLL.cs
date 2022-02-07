using System;
using Tarea3LabRegistros.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Tarea3LabRegistros.BLL
{
    public class EstudiantesBLL
    {

        public static bool Existe(int estudianteId)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Estudiantes.Any(l => l.EstudianteId == estudianteId);
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

        public static bool Guardar(Estudiantes estudiantes)
        {
            if (!Existe(estudiantes.EstudianteId))
                return Insertar(estudiantes);
            else
                return Modificar(estudiantes);

        }

        private static bool Insertar(Estudiantes estudiante)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
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
            Contexto contexto = new Contexto();
            bool paso = false;
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

        public static bool Eliminar(int estudianteId)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                var estudiante = contexto.Estudiantes.Find(estudianteId);
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

        public static Estudiantes? Buscar(int estudianteId)
        {
            Contexto contexto = new Contexto();
            Estudiantes? estudiante;
            try
            {
                estudiante = contexto.Estudiantes.Find(estudianteId);
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

        public static List<Estudiantes> GetList(Expression<Func<Estudiantes, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Estudiantes> lista = new List<Estudiantes>();
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