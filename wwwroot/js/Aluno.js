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


    let btnAdd = document.querySelector("#btnAddNew")
    btnAdd.addEventListener('click', addAluno)

    function addAluno() {

        let $Nome = document.querySelector("#inputNome")
        let $CPF = document.querySelector("#inputCpf")
        let $DataNascimento = document.querySelector("#inputDate")
        let $Escola = document.querySelector("#inputEscola")
        let $Turma = document.querySelector("#inputTurma")

        let dataAlunos = { NomeCompleto: $Nome.value, CPF: $CPF.value, DataNascimento: $DataNascimento.value, Escola: $Escola.value, Turma: $Turma.value }

        console.log(dataAlunos)

        $.ajax({
            contentType: "application/json",
            url: '/alunoadd',
            type: 'GET',
            dataType: 'json',
            data: dataAlunos,
            success: function (data) {

            },
            error: function (response) {
                alert("Error: " + response)
            }
        })
    }
}




//Máscara

