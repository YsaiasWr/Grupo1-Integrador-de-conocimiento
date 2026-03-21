using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Domain.Interfaces;

namespace SistemaRecursosHumanos.Application.UseCases
{
    public class RegistrarAsistenciaUseCase
    {
        private readonly IAsistenciaRepositorio _repo;

        public RegistrarAsistenciaUseCase(IAsistenciaRepositorio repo)
        {
            _repo = repo;
        }

        public void Ejecutar(Asistencia asistencia)
        {
            if (asistencia.HoraSalida < asistencia.HoraEntrada)
                throw new Exception(“La hora de salida no puede ser menor que la de entrada.”);

            _repo.Agregar(asistencia);
        }
    }
}

