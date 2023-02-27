let btnAddTurma = document.querySelector("#btnAddTurma")
btnAddTurma.addEventListener("click", popupCreateTurma)

function popupCreateTurma() {
    Swal.fire({
        template: '#my-templateTurmaCreate',
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
    btnAdd.addEventListener('click', addTurma)

    function addTurma() {

        let NomeEscola = document.querySelector("#optionEscola")
        let $NomeEscola = NomeEscola.options[NomeEscola.selectedIndex].value;

        let $NomeTurma = document.querySelector("#inputNomeTurma")

        let dataTurma = { NomeEscola: $NomeEscola, NomeTurma: $NomeTurma.value }
        console.log(dataTurma)

        $.ajax({
            contentType: "application/json",
            url: '/turmaadd',
            type: 'GET',
            dataType: 'json',
            data: dataTurma,
            success: function (data) {
                console.log(data)
                onSucess("Turma adicionada com sucesso.")
            },
            error: function (response) {
                onFail("Ocorreu um erro ao adicionar o aluno.")
            }
        })

    }

    $.ajax({
        contentType: "application/json",
        url: '/allescolas',
        type: 'GET',
        dataType: 'json',
        success: function (data) {

            console.log(data)

            if (data.length == 0) {
                alert("Não existe escolas cadastradas")
            }

            for (let i = 0; i < data.length; i++) {
                numberInputElementCreator('option', 'optionSelect', 'optionEscola', data[i].nome_Escola)
            }

        },
        error: function (response) {
        }
    })

}

window.addEventListener('load', SearchTurmas)

function SearchTurmas() {

    $.ajax({
        contentType: "application/json",
        url: '/allturma',
        type: 'GET',
        dataType: 'json',
        success: function (data) {

            console.log(data)

            $('#tabelaTurma').DataTable({
                data: data,
                columns: [
                    { "data": "iD_Turma" },
                    { "data": "nome_Turma" },
                    { "data": "nome_Escola" },
                    { "data": "qtd_Alunos" },

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

function numberInputElementCreator(element, id, elementPai, value) {
    let newElement = document.createElement(element)
    newElement.id = id
    newElement.textContent = value
    document.querySelector(`#${elementPai}`).appendChild(newElement);
}

