
let btnAddAluno = document.querySelector("#btnAddAluno")
btnAddAluno.addEventListener("click", popupCreateAluno)

function popupCreateAluno() {
    Swal.fire({
        template: '#my-templateAlunoCreate',
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

    //$.ajax({
    //    contentType: "application/json",
    //    url: '/allescolas',
    //    type: 'GET',
    //    dataType: 'json',
    //    success: function (data) {

    //        console.log(data)

    //        if (data.length == 0) {
    //            alert("Não existe escolas cadastradas")
    //        }

    //        for (let i = 0; i < data.length; i++) {
    //            numberInputElementCreator('option', 'optionSelect', 'optionEscola', data[i].nome_Escola)
    //        }

    //    },
    //    error: function (response) {
    //    }
    //})

    //$.ajax({
    //    contentType: "application/json",
    //    url: '/allturmas',
    //    type: 'GET',
    //    dataType: 'json',
    //    success: function (data) {

    //        console.log(data)

    //        if (data.length == 0) {
    //            alert("Não existe escolas cadastradas")
    //        }

    //        for (let i = 0; i < data.length; i++) {
    //            numberInputElementCreator('option', 'optionSelect', 'optionTurmas', data[i].nome_Escola)
    //        }

    //    },
    //    error: function (response) {
    //    }
    //})


    let btnAdd = document.querySelector("#btnAddNew")
    btnAdd.addEventListener('click', addAluno)

    function addAluno() {

        let $Nome = document.querySelector("#inputNome")
        let $CPF = document.querySelector("#inputCpf")
        let $DataNascimento = document.querySelector("#inputDate")

        let Escola = document.querySelector("#optionEscola")
        let Turma = document.querySelector("#optionTurma")

        let $Escola = Escola.options[Escola.selectedIndex].value;
        let $Turma = Turma.options[Turma.selectedIndex].value;     

        let dataAlunos = { NomeCompleto: $Nome.value, CPF: $CPF.value, DataNascimento: $DataNascimento.value, Escola: $Escola.value, Turma: $Turma.value }

        $.ajax({
            contentType: "application/json",
            url: '/alunoadd',
            type: 'GET',
            dataType: 'json',
            data: dataAlunos,
            success: function (data) {

                onSucess("Aluno adicionado com sucesso.")
            },
            error: function (response) {
                onFail("Ocorreu um erro ao adicionar o aluno.")
            }
        })
       
    }
}

window.addEventListener('load', SearchAlunos)

function SearchAlunos() {

    $.ajax({
        contentType: "application/json",
        url: '/allalunos',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            console.log(data)
            $('#tabelaAlunos').DataTable({
                data: data,
                columns: [
                    { "data": "iD_ALUNO" },
                    { "data": "nome_Completo", },
                    { "data": "turma" },
                    { "data": "cpf" },
                    { "data": "data_Nascimento" },
                    { "data": "status_Cadastro" },
                ],
                "columnDefs": [
                    {
                        "targets": 6, //"Número referente a coluna, startando no 0"
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

function InfoAluno(Linha) {

    var objTr = $(Linha).parent('td').parent('tr');
    let ID = objTr.find('td:eq(0)').text().trim();

    Swal.fire({
        template: '#my-templateAlunoEdit',
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

    let $Nome = document.querySelector("#inputNome")
    let $DataNascimento = document.querySelector("#inputDate")
    let $CPF = document.querySelector("#inputCpf")
    let StatusOption = document.querySelector("#optionStatus")
    let EscolaOption = document.querySelector("#optionEscola")
    let TurmaOption = document.querySelector("#optionTurma")

    let dataId = { "Id": ID}

    $.ajax({
        contentType: "application/json",
        url: '/infoaluno',
        type: 'GET',
        dataType: 'json',
        data: dataId,
        success: function (data) {
         
            $Nome.value = data['nome_Completo']
            $DataNascimento.value = data['data_Nascimento']
            $CPF.value = data['cpf']
            StatusOption.option = data['status_Cadastro']
            /*TurmaOption.option = data['turma']*/
            
        },
        error: function (data) {
            alert("Error: " + data)
        }
    })

    let btnAlterar = document.querySelector("#btnAlterar")
    btnAlterar.addEventListener('click', EditarAluno)

    function EditarAluno() {

        let $Status = StatusOption.options[StatusOption.selectedIndex].value;
/*      let $Escola = EscolaOption.options[EscolaOption.selectedIndex].value;*/
        let $Turma = TurmaOption.options[TurmaOption.selectedIndex].value;

        let objData = { "Id": ID, "StatusCadastro": $Status, "Turma": $Turma}
    
        $.ajax({
            contentType: "application/json",
            url: '/editaluno',
            type: 'GET',
            dataType: 'json',
            data: objData,
            success: function (data) {

                onSucess("Informações atualizadas com sucesso.")

            },
            error: function (data) {
                onFail("Ocorreu um erro ao atualizar as informações do aluno.")
            }
        })
    }

    let btnApagar = document.querySelector("#btnRemover")
    btnApagar.addEventListener('click', ApagarAluno)

    function ApagarAluno() {

        let objData = { "Id": ID}

        $.ajax({
            contentType: "application/json",
            url: '/apagaraluno',
            type: 'GET',
            dataType: 'json',
            data: objData,
            success: function (data) {

                onSucess("Aluno removido com sucesso.")

            },
            error: function (data) {
                onFail("Ocorreu um erro ao remover o aluno.")
            }
        })
    }


}

function onSucess(mensagem) {
    const popupSucess = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000,
        timerProgressBar: true,
        didOpen: (toast) => {
            toast.addEventListener('mouseenter', Swal.stopTimer)
            toast.addEventListener('mouseleave', Swal.resumeTimer)
        }

    })

    popupSucess.fire({
        icon: 'success',
        title: mensagem
    })

    setTimeout(function () {
        window.location.reload();
    }, 3000);
}

function onFail(mensagem) {
    const popupError = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000,
        timerProgressBar: true,
        didOpen: (toast) => {
            toast.addEventListener('mouseenter', Swal.stopTimer)
            toast.addEventListener('mouseleave', Swal.resumeTimer)
        }
    })
    popupError.fire({
        icon: 'error',
        title: mensagem
    })

}

function numberInputElementCreator(element, id, elementPai, value) {
    let newElement = document.createElement(element)
    newElement.id = id
    newElement.textContent = value
    document.querySelector(`#${elementPai}`).appendChild(newElement);
}
