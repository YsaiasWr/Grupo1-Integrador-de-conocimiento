# Crear labels de modulos
$modulos = @("Gestion de Empleados","Departamentos","Cargos y Puestos","Asistencia","Nomina","Usuarios y Roles","Reportes","Seguridad")
$prioridades = @("Alta","Media","Baja")

foreach ($m in $modulos) {
  gh label create "$m" --color "1D76DB" --force
}

foreach ($p in $prioridades) {
  gh label create "$p" --color "D93F0B" --force
}

$historias = @(
  # MODULO: Gestion de Empleados (Alta)
  @{Modulo="Gestion de Empleados"; Prioridad="Alta"; Texto="Como administrador, quiero registrar empleados para llevar el control del personal de la empresa."},
  @{Modulo="Gestion de Empleados"; Prioridad="Alta"; Texto="Como administrador, quiero editar la informacion de un empleado para mantener sus datos actualizados."},
  @{Modulo="Gestion de Empleados"; Prioridad="Alta"; Texto="Como administrador, quiero eliminar empleados para depurar registros obsoletos."},
  @{Modulo="Gestion de Empleados"; Prioridad="Media"; Texto="Como usuario, quiero consultar la lista de empleados para visualizar el personal activo."},
  @{Modulo="Gestion de Empleados"; Prioridad="Media"; Texto="Como administrador, quiero asignar un cargo a cada empleado para definir su funcion en la empresa."},
  @{Modulo="Gestion de Empleados"; Prioridad="Media"; Texto="Como administrador, quiero asignar un departamento a un empleado para organizar el personal por area."},

  # MODULO: Departamentos (Alta)
  @{Modulo="Departamentos"; Prioridad="Alta"; Texto="Como administrador, quiero crear departamentos para estructurar la empresa."},
  @{Modulo="Departamentos"; Prioridad="Media"; Texto="Como administrador, quiero modificar departamentos para reflejar cambios organizacionales."},
  @{Modulo="Departamentos"; Prioridad="Media"; Texto="Como administrador, quiero eliminar departamentos para reorganizar la empresa."},
  @{Modulo="Departamentos"; Prioridad="Baja"; Texto="Como usuario, quiero ver los departamentos existentes para conocer la estructura organizacional."},

  # MODULO: Cargos y Puestos (Alta)
  @{Modulo="Cargos y Puestos"; Prioridad="Alta"; Texto="Como administrador, quiero registrar cargos para definir los roles de trabajo."},
  @{Modulo="Cargos y Puestos"; Prioridad="Media"; Texto="Como administrador, quiero editar cargos para actualizar funciones laborales."},
  @{Modulo="Cargos y Puestos"; Prioridad="Media"; Texto="Como administrador, quiero eliminar cargos para depurar puestos no usados."},
  @{Modulo="Cargos y Puestos"; Prioridad="Baja"; Texto="Como usuario, quiero consultar los cargos disponibles para conocer los roles existentes."},

  # MODULO: Asistencia (Alta)
  @{Modulo="Asistencia"; Prioridad="Alta"; Texto="Como empleado, quiero registrar mi entrada y salida para llevar control de mi horario."},
  @{Modulo="Asistencia"; Prioridad="Alta"; Texto="Como administrador, quiero consultar la asistencia por fecha para verificar cumplimiento laboral."},
  @{Modulo="Asistencia"; Prioridad="Media"; Texto="Como administrador, quiero corregir registros de asistencia para solucionar errores."},

  # MODULO: Nomina (Alta)
  @{Modulo="Nomina"; Prioridad="Alta"; Texto="Como administrador, quiero calcular la nomina para pagar correctamente a los empleados."},
  @{Modulo="Nomina"; Prioridad="Alta"; Texto="Como administrador, quiero generar recibos de pago para documentar los salarios."},
  @{Modulo="Nomina"; Prioridad="Media"; Texto="Como usuario, quiero consultar la nomina para verificar los pagos realizados."},

  # MODULO: Usuarios y Roles (Alta)
  @{Modulo="Usuarios y Roles"; Prioridad="Alta"; Texto="Como administrador, quiero crear usuarios del sistema para permitir acceso a la aplicacion."},
  @{Modulo="Usuarios y Roles"; Prioridad="Alta"; Texto="Como administrador, quiero asignar roles a los usuarios para controlar permisos."},
  @{Modulo="Usuarios y Roles"; Prioridad="Alta"; Texto="Como usuario, quiero iniciar sesion para acceder al sistema de forma segura."},
  @{Modulo="Usuarios y Roles"; Prioridad="Media"; Texto="Como administrador, quiero bloquear usuarios para proteger el sistema."},

  # MODULO: Reportes (Media)
  @{Modulo="Reportes"; Prioridad="Media"; Texto="Como administrador, quiero generar reportes de empleados para analisis del personal."},
  @{Modulo="Reportes"; Prioridad="Media"; Texto="Como administrador, quiero generar reportes de asistencia para control laboral."},
  @{Modulo="Reportes"; Prioridad="Media"; Texto="Como administrador, quiero generar reportes de nomina para auditorias."},

  # MODULO: Seguridad (Alta)
  @{Modulo="Seguridad"; Prioridad="Alta"; Texto="Como usuario, quiero cerrar sesion para proteger mi informacion."},
  @{Modulo="Seguridad"; Prioridad="Alta"; Texto="Como sistema, quiero validar credenciales para evitar accesos no autorizados."},
  @{Modulo="Seguridad"; Prioridad="Alta"; Texto="Como administrador, quiero hacer copias de seguridad para proteger los datos."}
)

$contador = 1

foreach ($h in $historias) {
  $id = "HU-" + "{0:D2}" -f $contador
  $titulo = "$id - $($h.Modulo)"
  $cuerpo = $h.Texto + "`n`nModulo: " + $h.Modulo + "`nPrioridad: " + $h.Prioridad

  gh issue create `
    --title "$titulo" `
    --body "$cuerpo" `
    --label "$($h.Modulo),$($h.Prioridad)"

  $contador++
}