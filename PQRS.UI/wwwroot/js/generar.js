var Solicitud = {
    type: 0,
    init() {
        Solicitud.config();
    },
    config() {
        const selectSolicitud = document.getElementById('TipoSoli');
        selectSolicitud.addEventListener('change', (e) => {
            Solicitud.show(SolitudType[event.target.value]);
        });
        const buttonSave = document.getElementById('btnGuardar');
        buttonSave.addEventListener('click', (e) => {
            e.preventDefault();
            e.stopPropagation();
            Solicitud.save();
        });
    },
    show(toShow) {
        Solicitud.type = toShow;
        const solicitudes = document.querySelectorAll('.solicitudType.d-block');
        if (solicitudes) {
            solicitudes.forEach(el => {
                el.classList.remove('d-block');
                el.classList.add('d-none');
            });
        }
        const curSolicitud = document.getElementById(toShow);
        curSolicitud.classList.remove('d-none');
        curSolicitud.classList.add('d-block');
    },
    save() {
        axios.post(`https://localhost:44362/api/Solicitud/${Solicitud.type}`, Solicitud.prepareData())
            .then(function (response) {
                console.log(response);
            })
            .catch(function (error) {
                console.log(error);
            });
    },
    prepareData() {
        let data = {
            Area: parseInt(document.getElementById('Area').value),
            IdCliente: parseInt(document.getElementById('IdCliente').value),
            Servicio: parseInt(document.getElementById('Servicio').value),
            TipoSoli: parseInt(document.getElementById('TipoSoli').value),
            Fecha: moment().format('MMMM Do YYYY, h:mm:ss a'),
        }
        const type = Solicitud.type;
        switch (Solicitud.type) {
            case 'Peticion':
                data = {
                    ...data,
                    IdPeticion: 0,
                    IdSupervisor: parseInt(document.getElementById(`#${type} #IdSupervisor`).value)
                }
                break;
            case 'Queja':
                data = {
                    ...data,
                    IdQueja: 0,
                    IdSupervisor: document.querySelector(`#${type} #IdSupervisor`).value,
                    IdTipoRemuneracion: parseInt(document.getElementById(`#${type} #IdTipoRemuneracion`).value)
                }
                break;
            case 'Reclamo':
                data = {
                    ...data,
                    IdReclamo: 0,
                    IdTipoReclamo: parseInt(document.querySelector(`#${type} #IdTipoReclamo`).value),
                    IdSolucion: parseInt(document.querySelector(`#${type} #IdSolucion`).value),
                    Costo: parseFloat(document.querySelector(`#${type} #Costo`).value)
                }
                break;
            case 'Sugerencia':
                data = {
                    ...data,
                    IdSugerencia: 0,
                    IdTipoSugerencia: parseInt(document.querySelector(`#${type} #IdTipoSugerencia`).value),
                    Descripcion: parseInt(document.querySelector(`#${type} #Descripcion`).value),
                }
                break;
            case 'Felicitacion':
                data = {
                    ...data,
                    IdReclamo: 0,
                    IdFelicitacion: 0,
                    Descripcion: document.querySelector(`#${type} #Descripcion`).value,
                }
                break;
        }
        return JSON.stringify(data);
    }
};
(Solicitud.init)();