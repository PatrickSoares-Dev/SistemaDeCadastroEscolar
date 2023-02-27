let btnAddEscola = document.querySelector("#btnAddEscola")
btnAddEscola.addEventListener("click", popupCreateEscola)

function popupCreateEscola() {
    Swal.fire({
        template: '#my-templateEscolaCreate',
        toast: false,
        width: 650,
        showCloseButton: false,
        showCancelButton: false,
        showConfirmButton: false,
        showClass: {
            popup: 'animate__animated animate__fadeInDown',
        },
        hideClass: {
            popup: 'animate__animated animate__fadeOutUp',
        },
    })


    //Campos do PoPup


    let btnAdd = document.querySelector("#btnAddNew")
    btnAdd.addEventListener('click', addEscola)

    function addEscola() {

        let $Nome = document.querySelector("#inputNome")

        let dataEscola = { NomeEscola: $Nome.value }
        console.log(dataEscola)

        $.ajax({
            contentType: "application/json",
            url: '/escolaadd',
            type: 'GET',
            dataType: 'json',
            data: dataEscola,
            success: function (data) {

                onSucess("Escola adicionada com sucesso.")
            },
            error: function (response) {
                onFail("Ocorreu um erro ao adicionar o aluno.")
            }
        })

    }
}

window.addEventListener('load', SearchEscolas)

function SearchEscolas() {

    $.ajax({
        contentType: "application/json",
        url: '/allescolas',
        type: 'GET',
        dataType: 'json',
        success: function (data) {

            console.log(data)

            $('#tabelaEscola').DataTable({
                data: data,
                columns: [
                    { "data": "iD_Escola" },
                    { "data": "nome_Escola" },
                    { "data": "qtde_Turmas" },
                    { "data": "qtde_Alunos" },

                ],
                "columnDefs": [
                    {
                        "targets": 4, //"Número referente a coluna, startando no 0"
                        "render": function (data, type, row) {
                            return "<button id='" + data + "' type='button' onclick='InfoAluno(this);'class='btn btn-primary'>Editar</button >";
                        }
                    }
                ]
            });
        },
        error: function (data) {
            alert("Error: " + data)
        }
    })
}