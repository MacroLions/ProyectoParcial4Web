use Parcial4
select * from Paciente
/*Inicia Doctor*/

Create table Doctor(
idDoctor int Not Null Primary key IDENTITY(1, 1),
nombreDoctor varchar(20),
especialidadDoctor varchar(20),
)

select * from paciente
create proc Select_Doctor(
@iddoctor int)
as
begin
	Select
	iddoctor, nombreDoctor, especialidadDoctor
	from Doctor where idDoctor= @iddoctor
end


create proc SelectAll_Doctor
as
begin
	Select
	iddoctor, nombreDoctor, especialidadDoctor
	from Doctor 
end


create proc Save_Doctor(
@nombredoctor varchar(20),
@especialidaddoctor varchar(20))
as
begin
	insert into Doctor(nombreDoctor, especialidadDoctor) values (@nombredoctor, @especialidaddoctor)
end

create proc Edit_Doctor(
@iddoctor int,
@nombredoctor varchar(20) null,
@especialidaddoctor varchar(20) null)
as
begin
	update Doctor set
	nombreDoctor = isnull(@nombredoctor, nombreDoctor),
	especialidadDoctor = isnull(@especialidaddoctor,especialidadDoctor)
	where idDoctor= @iddoctor

end

create proc Delete_Doctor(
@iddoctor int)
as
begin
	delete from Doctor where idDoctor = @iddoctor
end


/*Terminar Doctor*/
/***************/
/***************/
/***************/


/*Inicia Clinica*/

Create table Clinica(
idClinica int Not Null Primary key IDENTITY(1, 1),
nombreClinica varchar(20),
idDoctorAsignado int,
Foreign Key(idDoctorAsignado) REFERENCES Doctor(idDoctor),
)

create proc Select_Clinica(
@idclinica int)
as
begin
	Select
	idClinica, nombreClinica, idDoctorAsignado
	from Clinica where idClinica= @idclinica
end


create proc SelectAll_Clinica
as
begin
	Select
	idClinica, nombreClinica, idDoctorAsignado
	from Clinica 
end


create proc Save_Clinica(
@nombreclinica varchar(20),
@iddoctorasignado int)
as
begin
	insert into Clinica(nombreClinica, idDoctorAsignado) values (@nombreclinica, @iddoctorasignado)
end

create proc Edit_Clinica(
@idclinica int,
@nombreclinica varchar(20) null,
@iddoctorasignado int null)
as
begin
	update Clinica set
	nombreClinica = isnull(@nombreclinica, nombreClinica),
	idDoctorAsignado = isnull(@iddoctorasignado,idDoctorAsignado)
	where idClinica= @idclinica

end

create proc Delete_Clinica(
@idclinica int)
as
begin
	delete from Clinica where idClinica = @idclinica
end

/*Terminar Clinica*/
/***************/
/***************/
/***************/



/*Inicia Horario*/

Create table Horario(
idHorario int Not Null Primary key IDENTITY(1, 1),
horarioApertura time,
horarioCierre time,
idClinicaAsignada int,
Foreign Key(idClinicaAsignada) REFERENCES Clinica(idClinica),
)

create proc Select_Horario(
@idhorario int)
as
begin
	Select
	idHorario, horarioApertura, horarioCierre, idclinicaAsignada
	from Horario where idHorario= @idhorario
end

create proc SelectAll_Horario
as
begin
	Select
	idHorario, horarioApertura, horarioCierre, idclinicaAsignada
	from Horario
end

exec Save_Doctor 'Luis Miguel', 'Traumatologo'
exec Save_Clinica 'Trauma Center','1'
exec Save_Horario '6:00','00:00',1

create proc Save_Horario(
@horarioapertura time,
@horariocierre time,
@idclinicaasignada int)
as
begin
	insert into Horario(horarioApertura,horarioCierre, idClinicaAsignada) values (@horarioapertura,@horariocierre, @idclinicaasignada)
end


create proc Edit_Horario(
@idhorario int,
@horarioapertura time null,
@horariocierre time null,
@idclinicaasignada int null)
as
begin
	update Horario set
	horarioApertura = isnull(@horarioapertura, horarioApertura),
	horarioCierre = isnull(@horariocierre, horarioCierre),
	idClinicaAsignada = isnull(@idclinicaasignada,idClinicaAsignada)
	where idHorario = @idhorario

end

create proc Delete_Horario(
@idhorario int)
as
begin
	delete from Horario where idHorario = @idhorario
end


/*Terminar Horario*/

/***************/
/***************/
/***************/

/* Inicia Paciente/Usuario */

Create table Paciente(
idPaciente int Not Null Primary key IDENTITY(1, 1),
nombrePaciente varchar(20),
apellidoPaciente varchar(20),
correo varchar(50),
usuario varchar(20),
pass varchar(max),
)

create proc Select_Paciente(
@idpaciente int)
as
begin
	Select
	idPaciente, nombrePaciente, apellidoPaciente, correo, usuario, pass
	from Paciente where idPaciente = @idpaciente
end

create proc SelectAll_Paciente
as
begin
	Select
	idPaciente, nombrePaciente, apellidoPaciente,correo, usuario, pass
	from Paciente
end


create proc Save_Paciente(
@nombrepaciente varchar(20),
@apellidopaciente varchar(20),
@correo varchar(50),
@pass varchar(max))
as
begin
Declare
	@letras_nombre varchar(3),
	@usuario varchar(20);
	set @letras_nombre = Left(@nombrepaciente,3);

	set @usuario = upper(@letras_nombre) + cast(cast((rand()*10000) as int) as varchar)

	insert into Paciente(nombrePaciente,apellidoPaciente,correo, Usuario, Pass) values (@nombrepaciente,@apellidopaciente,@correo,@usuario,@pass)
end


create proc Edit_Paciente(
@idpaciente int,
@nombrepaciente varchar(20) null,
@apellidopaciente varchar(20) null,
@correo varchar(50) null,
@usuario varchar(20) null,
@pass varchar(max) null)
as
begin
	update Paciente set
	nombrePaciente = isnull(@nombrepaciente, nombrePaciente),
	apellidoPaciente = isnull(@apellidopaciente, apellidoPaciente),
	correo = isnull(@correo, correo),
	usuario = isnull(@usuario,usuario),
	pass = isnull(@pass, pass)
	where idPaciente = @idpaciente

end

create proc Delete_Paciente(
@idpaciente int)
as
begin
	delete from Paciente where idPaciente = @idpaciente
end

/*Termina Paciente*/

/***************/
/***************/
/***************/

/*Inicia Cita*/
Create table Cita(
idCita int Not Null Primary key IDENTITY(1, 1),
idPaciente int,
Foreign Key(idPaciente) REFERENCES Paciente(idPaciente),
idClinica int,
Foreign Key(idClinica) REFERENCES Clinica(idClinica),
fechaCita date,
horaCita time,
)

create proc Select_Cita(
@idcita int)
as
begin
	Select
	idCita,idPaciente,idClinica,fechaCita,horaCita
	from Cita where idCita = @idcita
end

create proc SelectAll_Cita
as
begin
	Select
	idCita,idPaciente,idClinica,fechaCita,horaCita
	from Cita
end

exec Save_Cita '3','1','2022/12/30',"00:05"

select * from Cita

create proc Save_Cita(
@idpaciente int,
@idclinica int,
@fechacita date,
@horacita time)
as
begin
	insert into Cita(idPaciente,idClinica,fechaCita,horaCita) values (@idpaciente,@idclinica,@fechacita,@horacita)
end

create proc Edit_Cita(
@idcita int,
@idpaciente int null,
@idclinica int null,
@fechacita date null,
@horacita time null)
as
begin
	update Cita set
	idPaciente = isnull(@idpaciente, idPaciente),
	idClinica = isnull(@idclinica, idClinica),
	fechaCita = isnull(@fechacita, fechaCita),
	horaCita = isnull(@horacita,horaCita)
	where idCita = @idcita

end

create proc Delete_Cita(
@idcita int)
as
begin
	delete from Cita where idCita = @idcita
end
/*Termina Cita*/

/***************/
/***************/
/***************/

/*Inicia Examen*/
Create table Examen(
idExamen int Not Null Primary key IDENTITY(1, 1),
nombreExamen varchar(50),
idPaciente int,
Foreign Key(idPaciente) REFERENCES Paciente(idPaciente)
)

create proc Select_Examen(
@idexamen int)
as
begin
	Select
	idExamen,nombreExamen,idPaciente
	from Examen where idExamen = @idexamen
end

create proc SelectAll_Examen
as
begin
	Select
	idExamen,nombreExamen,idPaciente
	from Examen
end


create proc Save_Examen(
@nombreExamen varchar(50),
@idPaciente int)
as
begin
	insert into Examen(nombreExamen,idPaciente) values (@nombreExamen,@idPaciente)
end


create proc Edit_Examen(
@idexamen int,
@nombreExamen varchar(50) null,
@idpaciente int null)
as
begin
	update Examen set
	nombreExamen = isnull(@nombreExamen, nombreExamen),
	idPaciente = isnull(@idpaciente, idPaciente)
	where idExamen = @idexamen

end

create proc Delete_Examen(
@idexamen int)
as
begin
	delete from Examen where idExamen = @idexamen
end

/*Termina Examen*/

/***************/
/***************/
/***************/

/*Inicia Medicamento*/
Create table Medicamento(
idMedicamento int Not Null Primary key IDENTITY(1, 1),
nombreMedicamento varchar(50),
idPaciente int,
Foreign Key(idPaciente) REFERENCES Paciente(idPaciente)
)

create proc Select_Medicamento(
@idmedicamento int)
as
begin
	Select
	idMedicamento,nombreMedicamento,idPaciente
	from Medicamento where idmedicamento = @idmedicamento
end

create proc SelectAll_Medicamento
as
begin
	Select
	idMedicamento,nombreMedicamento,idPaciente
	from Medicamento
end


create proc Save_Medicamento(
@nombreMedicamento varchar(50),
@idPaciente int)
as
begin
	insert into Medicamento(nombreMedicamento,idPaciente) values (@nombreMedicamento,@idPaciente)
end


create proc Edit_Medicamento(
@idmedicamento int,
@nombreMedicamento varchar(50) null,
@idpaciente int null)
as
begin
	update Medicamento set
	nombreMedicamento = isnull(@nombreMedicamento, nombreMedicamento),
	idPaciente = isnull(@idpaciente, idPaciente)
	where idMedicamento = @idmedicamento

end

create proc Delete_Medicamento(
@idmedicamento int)
as
begin
	delete from Medicamento where idMedicamento = @idmedicamento
end
/*Termina Medicamento*/

/***************/
/***************/
/***************/

/*Inicia Diagnostico*/
Create table Diagnostico(
idDiagnostico int Not Null Primary key IDENTITY(1, 1),
nombreDiagnostico varchar(50),
idPaciente int,
Foreign Key(idPaciente) REFERENCES Paciente(idPaciente)
)

create proc Select_Diagnostico(
@iddiagnostico int)
as
begin
	Select
	idDiagnostico,nombreDiagnostico,idPaciente
	from Diagnostico where iddiagnostico = @iddiagnostico
end

create proc SelectAll_Diagnostico
as
begin
	Select
	idDiagnostico,nombreDiagnostico,idPaciente
	from Diagnostico
end


create proc Save_Diagnostico(
@nombreDiagnostico varchar(50),
@idPaciente int)
as
begin
	insert into Diagnostico(nombreDiagnostico,idPaciente) values (@nombreDiagnostico,@idPaciente)
end


create proc Edit_Diagnostico(
@iddiagnostico int,
@nombreDiagnostico varchar(50) null,
@idpaciente int null)
as
begin
	update Diagnostico set
	nombreDiagnostico = isnull(@nombreDiagnostico, nombreDiagnostico),
	idPaciente = isnull(@idpaciente, idPaciente)
	where idDiagnostico = @iddiagnostico

end

create proc Delete_Diagnostico(
@iddiagnostico int)
as
begin
	delete from Diagnostico where idDiagnostico = @iddiagnostico
end