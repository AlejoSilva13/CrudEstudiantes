using CrudEstudiantes.Busines.Request;
using CrudEstudiantes.Busines.Response;
using CrudEstudiantes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace CrudEstudiantes.Controllers
{
    [RoutePrefix("api/Crud")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CrudEstudiantesController : ApiController
    {
        private readonly BdCrudEstudiantes bd;

        CrudEstudiantesController()
        {
            bd = new BdCrudEstudiantes();
        }
        #region Estudiantes

        [HttpGet]
        [Route("consultarAlumno")]

        public JsonResult<ConsultarAlumnoRs> ConsultingStudent()
        {
            ConsultarAlumnoRs response = new ConsultarAlumnoRs();

            try
            {
                List<Estudiante> LstEstudiante = bd.Estudiante.OrderByDescending(x => x.Id).ToList();

                if (LstEstudiante.Count > 0)
                {
                    response.Estudiantes = LstEstudiante;
                }
                else
                {
                    response.Mensaje = "No hay datos";
                    response.IdError = -99;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Json(response);
        }

        [HttpPost]
        [Route("insertarAlumno")]

        public JsonResult<InsertarEstudianteRs> InsertStudent(InsertarEstudianteRq request)
        {
            InsertarEstudianteRs response = new InsertarEstudianteRs();

            try
            {
                Estudiante alumnos = bd.Estudiante.Where(x => x.Identificacion == request.Identificacion).OrderByDescending(x => x.Id).FirstOrDefault();

                if (alumnos == null)
                {
                    alumnos = new Estudiante
                    {
                        Identificacion = request.Identificacion,
                        Nombre = request.Nombre,
                    };

                    bd.Estudiante.Add(alumnos);
                    bd.SaveChanges();

                    response.Mensaje = "Estudiante insertado con exito";
                    response.IdError = 0;
                }
                else
                {
                    response.Mensaje = "Estudiante ya existe";
                    response.IdError = 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Json(response);
        }
        [HttpPut]
        [Route("actualizarAlumno")]

        public JsonResult<ActualizarEstudianteRs> UpdateStudent(ActualizarEstudianteRq request)
        {
            ActualizarEstudianteRs response = new ActualizarEstudianteRs();

            try
            {
                Estudiante alumnos = bd.Estudiante.Where(x => x.Identificacion == request.Identificacion).OrderByDescending(x => x.Id).FirstOrDefault();

                if (alumnos != null)
                {
                    alumnos.Identificacion = request.Identificacion;
                    alumnos.Nombre = request.Nombre;

                    bd.Entry(alumnos).State = EntityState.Modified;
                    bd.SaveChanges();

                    response.Mensaje = "Datos de estudiante actualizados con exito";
                    response.IdError = 0;
                }
                else
                {
                    response.Mensaje = "Estudiante no existe";
                    response.IdError = -3;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Json(response);
        }

        [HttpDelete]
        [Route("eliminarAlumnos")]

        public JsonResult<EliminarAlumnosRs> DeleteStudent(EliminarAlumnosRq request)
        {
            EliminarAlumnosRs response = new EliminarAlumnosRs();

            try
            {
                Estudiante alumnos = bd.Estudiante.Where(x => x.Id == request.Id).OrderByDescending(x => x.Id).FirstOrDefault();


                if (alumnos != null)
                {
                    bd.Estudiante.Remove(alumnos);
                    bd.SaveChanges();

                    response.Mensaje = "Alumno eliminado con exito";
                    response.IdError = 0;
                }
                else
                {
                    response.Mensaje = "Estudiante no existe";
                    response.IdError = -99;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Json(response);
        }
        #endregion

        #region Profesores

        [HttpGet]
        [Route("consultarAlumno")]

        public JsonResult<ConsultarProfesorRs> ConsultingTeacher()
        {
            ConsultarProfesorRs response = new ConsultarProfesorRs();

            try
            {
                List<Profesor> LstProfesor = bd.Profesor.OrderByDescending(x => x.Id).ToList();

                if (LstProfesor.Count > 0)
                {
                    response.Profesores = LstProfesor;
                }
                else
                {
                    response.Mensaje = "No hay datos";
                    response.IdError = -99;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Json(response);
        }

        [HttpPost]
        [Route("insertarProfesor")]

        public JsonResult<InsertarProfesorRs> InsertTeacher(InsertarProfesorRq request)
        {
            InsertarProfesorRs response = new InsertarProfesorRs();

            try
            {
                Profesor profesor = bd.Profesor.Where(x => x.Identificacion == request.Identificacion).OrderByDescending(x => x.Id).FirstOrDefault();

                if (profesor == null)
                {
                    profesor = new Profesor
                    {
                        Identificacion = request.Identificacion,
                        Nombre = request.Nombre,
                    };

                    bd.Profesor.Add(profesor);
                    bd.SaveChanges();

                    response.Mensaje = "Profesor insertado con exito";
                    response.IdError = 0;
                }
                else
                {
                    response.Mensaje = "Profesor ya existe";
                    response.IdError = 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Json(response);
        }
        [HttpPut]
        [Route("actualizarProfesor")]

        public JsonResult<ActualizarProfesorRs> UpdateTeacher(ActualizarProfesorRq request)
        {
            ActualizarProfesorRs response = new ActualizarProfesorRs();

            try
            {
                Profesor profesor = bd.Profesor.Where(x => x.Identificacion == request.Identificacion).OrderByDescending(x => x.Id).FirstOrDefault();

                if (profesor != null)
                {
                    profesor.Identificacion = request.Identificacion;
                    profesor.Nombre = request.Nombre;

                    bd.Entry(profesor).State = EntityState.Modified;
                    bd.SaveChanges();

                    response.Mensaje = "Datos de profesor actualizados con exito";
                    response.IdError = 0;
                }
                else
                {
                    response.Mensaje = "profesor no existe";
                    response.IdError = -3;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Json(response);
        }

        [HttpDelete]
        [Route("eliminarProfesor")]

        public JsonResult<EliminarProfesorRs> DeleteTeacher(EliminarProfesorRq request)
        {
            EliminarProfesorRs response = new EliminarProfesorRs();

            try
            {
                Profesor profesor = bd.Profesor.Where(x => x.Id == request.Id).OrderByDescending(x => x.Id).FirstOrDefault();


                if (profesor != null)
                {
                    bd.Profesor.Remove(profesor);
                    bd.SaveChanges();

                    response.Mensaje = "Profesor eliminado con exito";
                    response.IdError = 0;
                }
                else
                {
                    response.Mensaje = "Profesor no existe";
                    response.IdError = -99;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Json(response);
        }
        #endregion

        #region Nota
        [HttpGet]
        [Route("consultarNota")]

        public JsonResult<ConsultarNotaRs> ConsultingNote()
        {
            ConsultarNotaRs response = new ConsultarNotaRs();

            try
            {
                List<Nota> LstNota = bd.Nota.OrderByDescending(x => x.Id).ToList();

                if (LstNota.Count > 0)
                {
                    response.Notas = LstNota;
                }
                else
                {
                    response.Mensaje = "No hay datos";
                    response.IdError = -99;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Json(response);
        }

        [HttpPost]
        [Route("insertarNota")]

        public JsonResult<InsertarNotaRs> InsertNote(InsertarNotaRq request)
        {
            InsertarNotaRs response = new InsertarNotaRs();

            try
            {
                Nota nota = new Nota
                {
                     Nomre = request.Nombre,
                    IdProfesor = request.IdProfesor,
                    IdEstudiante = request.IdEstudiante,
                    valor = request.Valor,
                };

                bd.Nota.Add(nota);
                bd.SaveChanges();

                response.Mensaje = "Nota insertada con exito";
                response.IdError = 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Json(response);
        }
        [HttpPut]
        [Route("actualizarNota")]

        public JsonResult<ActualizarNotaRs> UpdateNote(ActualizarNotaRq request)
        {
            ActualizarNotaRs response = new ActualizarNotaRs();

            try
            {
                Nota nota = bd.Nota.Where(x => x.Id == request.Id).OrderByDescending(x => x.Id).FirstOrDefault();

                if (nota != null)
                {
                    nota.Nomre = request.Nombre;
                    nota.IdProfesor = request.IdProfesor;
                    nota.IdEstudiante = request.IdEstudiante;
                    nota.valor = request.Valor;

                    bd.Entry(nota).State = EntityState.Modified;
                    bd.SaveChanges();

                    response.Mensaje = "Datos de nota actualizados con exito";
                    response.IdError = 0;
                }
                else
                {
                    response.Mensaje = "nota no existe";
                    response.IdError = -3;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Json(response);
        }

        [HttpDelete]
        [Route("eliminarNota")]

        public JsonResult<EliminarNotaRs> DeleteNote(EliminarNotaRq request)
        {
            EliminarNotaRs response = new EliminarNotaRs();

            try
            {
                Nota nota = bd.Nota.Where(x => x.Id == request.Id).OrderByDescending(x => x.Id).FirstOrDefault();


                if (nota != null)
                {
                    bd.Nota.Remove(nota);
                    bd.SaveChanges();

                    response.Mensaje = "Nota eliminada con exito";
                    response.IdError = 0;
                }
                else
                {
                    response.Mensaje = "Nota no existe";
                    response.IdError = -99;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Json(response);
        }
        #endregion
    }
}