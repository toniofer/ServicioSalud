# ServicioSalud
.[!NOTE].
Sistema para gestionar las consultas médicas de los pacientes de un centro de salud y sus historias clínicas. Desarrollado en Genexus X

Se solicita una aplicación para ser instalada en un servicio de salud, que permita
gestionar las consultas que realizan los pacientes, junto con sus historias clínicas.
El servicio brinda consultas en distintas especialidades a sus pacientes asociados.
Para ello maneja tres turnos diarios: matutino, vespertino y nocturno. En esos
turnos, en cada uno de los 20 consultorios disponibles, habrá un médico de una
determinada especialidad, atendiendo a los pacientes que oportunamente hayan
pedido número para atenderse en esa consulta.

Médicos
Un médico es contratado para que atienda consultas de determinada
especialidad (y sólo de esa).
Se desea tener los siguientes datos: nombre, apellido, domicilio, teléfono,
estado civil, fecha de ingreso al servicio, especialidad y dos enfermeros/as
(el/la titular y el/la suplente) con los que trabajará en sus consultas. El sistema
deberá controlar en forma automática que el enfermero suplente sea distinto
del titular.

Especialidades
Cada especialidad tiene un código y una descripción. Además, para cada
especialidad existe un número máximo de pacientes a atender por consulta.
Enfermeros
Se desea almacenar nombre, apellido, domicilio, estado civil y fecha de ingreso
al servicio de cada enfermero/a.

Pacientes
Cada paciente se identifica por un número de socio (de seis dígitos, generado
automáticamente) y se tienen de él los siguientes datos: nombre, apellido,
domicilio, estado civil, fecha de nacimiento, fecha de ingreso al servicio y
documento de identidad (éste no puede repetirse).

Agenda de las consultas que brindará el servicio médico
La agenda con las consultas médicas que brindará el servicio un mes
determinado, es realizada por un supervisor con cierta antelación.
Cada consulta es:
• en cierta fecha.
• en cierto turno (matutino, vespertino o nocturno).
• atendida por un médico (de cierta especialidad).
• atendida en cierto consultorio (del 1 al 20).
Deberá controlarse lo siguiente:
• Un mismo médico no puede atender en un mismo turno en un mismo
día, en más de un consultorio.
• Al asignar los días y turnos de cada médico se debe tener en cuenta no
asignar un consultorio ocupado.
• De realizar consultas en 2 turnos consecutivos, éstas deben
desarrollarse en el mismo consultorio, no así para los distintos días de
consulta.

Nota: para simplificar, puede ser otro tab de los que utiliza el administrativo,
suponiendo que el administrativo y el médico utilizan el mismo panel para trabajar con
las consultas.

Estadísticas
Se necesita obtener en formato XML las estadísticas correspondientes al número de
consultas asignadas y de pacientes atendidos por cada médico, agrupados por
especialidad, dentro de un rango de fechas dado.

• Un médico puede atender hasta 2 turnos por día, no más.
Solicitud de consulta
Los pacientes pueden solicitar número para una consulta. El sistema debe
permitir seleccionar en un grid al paciente, por número de socio o documento
de identidad. Asimismo debe poder seleccionar una consulta filtrando por
médico y/o especialidad y/o fecha y/o turno.
Hay que tener en cuenta que para cada especialidad existe un número
máximo de pacientes a atender por consulta. Se desea tener visible siempre
la cantidad de números asignados y la cantidad de números aún disponibles
para cada consulta y no asignar un paciente a una consulta cuando se haya
alcanzado el máximo de pacientes permitidos.
Una vez que el paciente debidamente identificado elige la consulta deseada,
se agenda y se le emite la orden (ticket) donde figuran los datos: paciente,
médico, fecha de consulta, turno, y número para ser atendido (el día de la
consulta los pacientes serán atendidos en el orden correspondiente a los números que
se les entregaron; no se les asigna una hora de atención. Tendrán que ir a la hora de
comienzo del turno y esperar hasta que los pacientes con números anteriores hayan
sido atendidos secuencialmente).

Historias clínicas
Cada asistencia del paciente a una consulta determinada, se registra en el
sistema, donde figuran el motivo de la consulta y las anotaciones que realiza el
médico durante la misma.

Gestión de Consultas
El día de consulta, el paciente debe pasar por un mostrador central donde
confirma su asistencia mediante la presentación de la orden (ticket).
El administrativo o administrativa que lo atienda deberá seleccionar la
consulta en un panel donde podrá filtrarlas por apellido del médico y/o fecha
y/o turno. No podrá insertar nuevas consultas, ni eliminarlas. Solo podrá
actualizarlas, para modificar el número de consultorio.
Los datos que interesará visualizar de la consulta son:
• Número de consultorio
• Fecha
• Turno
• Médico
• Especialidad
• Máximo número de pacientes que es posible atender
• Cantidad de pacientes agendados para la consulta
• Cantidad de pacientes ya confirmados
Sobre el número de consultorio deberá haber un link que permita visualizar
los datos generales de la consulta (poner a ConsultorioNumero como
Descritpcion attribute)
(pudiendo desde allí solamente actualizarla para cambiar el consultorio)
(personalizar el View)
y en un tab un grid (acá hay que personalizar el tab (Consulta Paciente)) con
todos los pacientes de esa consulta, en el que se mostrarán los datos:
• Número de atención asignado (deberá mostrarse ordenado por esta
columna)
• Número de socio del paciente
• Nombre y apellido del paciente
• Si está o no confirmado
Para permitir registrar un paciente como confirmado, en este grid deberá
haber una imagen por cada paciente, que permita marcarlo como
confirmado.
Se pueden atender pacientes que no tenían número (siempre y cuando no se
haya alcanzado el máximo de pacientes para la especialidad), insertándolos
en la consulta. Se debe poder eliminar de la consulta a un paciente que llama
para cancelar (pero no se pueden modificar los datos).
Además, durante la consulta, el médico debe poder visualizar su lista de
pacientes confirmados (no pudiendo ingresar ni eliminar pacientes de la lista)
así como ingresar los datos: motivo de la consulta y anotaciones, en la
historia clínica de cada uno, a medida que los va atendiendo.

Nota: para simplificar, puede ser otro tab de los que utiliza el administrativo,
suponiendo que el administrativo y el médico utilizan el mismo panel para trabajar con
las consultas.
Estadísticas
Se necesita obtener en formato XML las estadísticas correspondientes al número de
consultas asignadas y de pacientes atendidos por cada médico, agrupados por
especialidad, dentro de un rango de fechas dado.

Listados
También se necesita desplegar un listado PDF que muestre la misma información que
el XML anterior.
Opcional: ¿Cómo lo haría si no desea que aparezcan en el listado los médicos a los que no se
les hayan asignado consultas en ese período?

Opcional: reemplazar cierto médico por otro en las consultas
El supervisor debe poder invocar un proceso que modifique el médico de todas las
consultas en determinado rango de fechas que éste iba a realizar, por otro,
suplente.

Opcional: ingreso de especialidad y médico
Únicamente se ingresa una especialidad cuando se ha contratado un médico
perteneciente a la misma. Se desea que el sistema asegure que nunca quede
ingresada una especialidad que no tenga algún médico asociado.
