$(function (){
    var dt = $('#tablaUsuarios').DataTable({
        order: [[0, 'asc']],
        language: {
            lengthMenu: "Mostrar _MENU_ registros por página",
            zeroRecords: "No se encontraron resultados",
            info: "Mostrando página _PAGE_ de _PAGES_",
            infoEmpty: "No hay registros disponibles",
            infoFiltered: "(filtrado de _MAX_ registros totales)",
            search: "Buscar:",
            paginate: {
                first: "Primero",
                last: "Último",
                next: "Siguiente",
                previous: "Anterior"

            }
        }
    });

        $('#buscarUsuarios').on('keyup', function (){
                   dt.search(this.value).draw();
    }); 
});


function abrirModal(idDiv, titulo){

        const contenido = document.getElementById(idDiv).innerHTML;
        document.getElementById('modalUsuarioLabel').textContent = titulo;
    document.getElementById('contenidoModalUsuario').innerHTML = contenido;
    let modal = new bootstrap.Modal(document.getElementById('modalUsuario'));
    modal.show();
}

function abrirModalCambioEstatus(idUsuario, activar) {
    const contenido = document.getElementById('estatus_' + idUsuario).innerHTML;
    document.getElementById('modalUsuarioLabel').textContent = activar ? "Activar Usuario" : "Cambiar Estatus";
    document.getElementById('contenidoModalUsuario').innerHTML = contenido;
    let modal = new bootstrap.Modal(document.getElementById('modalUsuario'));
    modal.show();

}
