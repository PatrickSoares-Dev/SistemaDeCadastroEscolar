window.addEventListener('load', SearchAlunos)

//Funcionando
//function SearchAlunos() {

//    $.ajax({
//        contentType: "application/json",
//        url: '/allalunos',
//        type: 'GET',
//        dataType: 'json',
//        success: function (data) {
//            console.log(data)

//            data = data.map(function (row) {
//                row.dataDeNascimento = new Date(row.dataDeNascimento).toLocaleDateString('pt-BR');
//                return row;
//            });
//            $('#tabelaAlunos').DataTable({
//                data: data,
//                columns: [
//                    { "data": "matricula" },
//                    { "data": "nome_Completo", },
//                    { "data": "iD_Turma" }, 
//                    { "data": "cpf" },
//                    { "data": "dataDeNascimento" },
//                    { "data": "status_Cadastro" },
//                ],
//                "columnDefs": [
//                    {
//                        "targets": 6,
//                        "render": function (data, type, row) {
//                            return "<button id='" + data + "' type='button' onclick='InfoAluno(this);'class='btn btn-primary'>Editar</button >";
//                        }
//                    }
//                ]
//            });

//        },
//        error: function (data) {
//            alert("Error: " + data)
//        }
//    });

//}


function SearchAlunos() {

    $.ajax({
        contentType: "application/json",
        url: '/allalunos',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            console.log(data)

            let dataTurma = data.map(row => row.iD_Turma)
            let dataEscola = data.map(row => row.iD_Escola)
                        

            data = data.map(function (row) {
                row.dataDeNascimento = new Date(row.dataDeNascimento).toLocaleDateString('pt-BR');
                return row;
            });

            let objData = { idEscola: dataEscola[0], idTurma: dataTurma[0] }
            console.log(objData)

            $.ajax({
                contentType: "application/json",
                url: '/getnameturmaeescola',
                type: 'GET',
                dataType: 'json',
                data: objData,
                success: function (data) {

                    console.log(data)


                },
                error: function (response) {
                }
            })

        },
        error: function (data) {
            alert("Error: " + data)
        }
    });

    //$('#tabelaAlunos').DataTable({
    //    data: data,
    //    columns: [
    //        { "data": "matricula" },
    //        { "data": "nome_Completo", },
    //        { "data": "iD_Turma" },
    //        { "data": "cpf" },
    //        { "data": "dataDeNascimento" },
    //        { "data": "status_Cadastro" },
    //    ],
    //    "columnDefs": [
    //        {
    //            "targets": 6,
    //            "render": function (data, type, row) {
    //                return "<button id='" + data + "' type='button' onclick='InfoAluno(this);'class='btn btn-primary'>Editar</button >";
    //            }
    //        }
    //    ]
    //});


}

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

    let Escola = document.querySelector("#optionEscola")
    let Turma = document.querySelector("#optionTurma")

    //Campos do PoPup

    $.ajax({
        contentType: "application/json",
        url: '/allescolas',
        type: 'GET',
        dataType: 'json',
        success: function (data) {

            console.log(data)

            if (data.length == 0) {
                onFail("Não existe ESCOLAS cadastradas.")
            }

            for (let i = 0; i < data.length; i++) {
                numberInputElementCreator('option', 'optionSelect', 'optionEscola', data[i].nome_Escola, data[i].iD_Escola)
            }

        },
        error: function (response) {
        }
    })

    Escola.addEventListener('change', function () {

        let divTurma = document.querySelector("#divTurma")
        let $Escola = Escola.options[Escola.selectedIndex].value;

        let objData = { idEscola: $Escola }

        $.ajax({
            contentType: "application/json",
            url: '/turmaescola',
            type: 'GET',
            dataType: 'json',
            data: objData,
            success: function (data) {

                let dataTurmas = data.turmas

                console.log(dataTurmas)

                if (dataTurmas.length == 0) {
                    onFail("Não existe TURMAS cadastradas.")
                }

                let optionTurma = document.querySelector("#optionTurma")
                optionTurma.innerHTML = "";
                divTurma.style.display = "block"

                for (let i = 0; i < dataTurmas.length; i++) {
                    numberInputElementCreator('option', 'optionSelect', 'optionTurma', dataTurmas[i].nome_Turma, dataTurmas[i].iD_Turma)
                }

            },
            error: function (response) {
            }
        })
    })

    let btnAdd = document.querySelector("#btnAddNew")
    btnAdd.addEventListener('click', addAluno)

    function addAluno() {

        let $Nome = document.querySelector("#inputNome")
        let $CPF = document.querySelector("#inputCpf")
        let $DataNascimento = document.querySelector("#inputDate")

        let $Escola = Escola.options[Escola.selectedIndex].value;
        let $Turma = Turma.options[Turma.selectedIndex].value;

        let dataAlunos = { Escola: $Escola, Turma: $Turma, NomeCompleto: $Nome.value, CPF: $CPF.value, DataNascimento: $DataNascimento.value }

        console.log(dataAlunos)

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

    let inputDate = document.querySelector('#inputDate');



    inputDate.addEventListener('input', function (event) {
        let value = event.target.value;
        value = value.replace(/\D/g, ''); // remove tudo que não for número
        value = value.replace(/(\d{2})(\d)/, '$1/$2'); // coloca a barra depois do segundo número
        value = value.replace(/(\d{2})(\d)/, '$1/$2'); // coloca a barra depois do quarto número
        event.target.value = value;
    });    

    // Seleciona o campo de CPF
    const cpfInput = document.querySelector('#inputCpf');

    // Adiciona um listener para o evento "input" no campo de CPF
    cpfInput.addEventListener('input', function (event) {
        // Obtém o valor atual do campo
        let value = event.target.value;

        // Remove todos os caracteres que não são números
        value = value.replace(/\D/g, '');

        // Adiciona a máscara de CPF
        value = value.replace(/(\d{3})(\d)/, '$1.$2');
        value = value.replace(/(\d{3})(\d)/, '$1.$2');
        value = value.replace(/(\d{3})(\d{1,2})$/, '$1-$2');

        // Define o valor formatado no campo
        event.target.value = value;
    });


    // Seleciona todos os inputs e selects do formulário
    const inputs = document.querySelectorAll('form input, form select');

    // Seleciona o botão "Cadastar"
    const btnAddNew = document.querySelector('#btnAddNew');

    // Função para verificar se o formulário está completamente preenchido
    function validateForm() {
        let valid = true;

        // Verifica os inputs
        inputs.forEach(input => {
            // Verifica se o campo está vazio ou tem valor inválido
            if (!input.value || (input.type === 'date' && input.value > new Date().toISOString().split('T')[0])) {
                valid = false;
                input.classList.add('is-invalid');
            } else {
                input.classList.remove('is-invalid');
            }
        });
        // Seleciona os selects que são obrigatórios
        const selects = document.querySelectorAll('form select[data-parsley-required="true"], #optionTurma');


        selects.forEach(select => {
            if (!select.value) {
                valid = false;
                select.classList.add('is-invalid');
            } else {
                select.classList.remove('is-invalid');
            }
        });

        return valid;
    }


    // Função para habilitar ou desabilitar o botão "Cadastar"
    function toggleButton() {
        btnAddNew.disabled = !validateForm();
    }

    // Adiciona um listener para verificar mudanças em todos os campos do formulário
    inputs.forEach(input => {
        input.addEventListener('change', toggleButton);

    });

    // Inicializa o botão "Cadastar" desabilitado
    toggleButton();


}


function InfoAluno(Linha) {

    var objTr = $(Linha).parent('td').parent('tr');
    let CPF = objTr.find('td:eq(3)').text().trim();

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

    let dataMatricula = { "CPF": CPF }

    $.ajax({
        contentType: "application/json",
        url: '/allescolas',
        type: 'GET',
        dataType: 'json',
        success: function (data) {

            for (let i = 0; i < data.length; i++) {
                numberInputElementCreator('option', 'optionSelect', 'optionEscola', data[i].nome_Escola, data[i].nome_Escola)
            }

        },
        error: function (response) {
        }
    })

    $.ajax({
        contentType: "application/json",
        url: '/turmas',
        type: 'GET',
        dataType: 'json',
        success: function (data) {

            let dataTurmas = data.turmas
            console.log(dataTurmas)

            for (let i = 0; i < dataTurmas.length; i++) {
                numberInputElementCreator('option', 'optionSelect', 'optionTurma', dataTurmas[i].nome_Turma, dataTurmas[i].nome_Turma)
            }

        },
        error: function (response) {
        }
    })


    $.ajax({
        contentType: "application/json",
        url: '/infoaluno',
        type: 'GET',
        dataType: 'json',
        data: dataMatricula,
        success: function (data) {
            $Nome.value = data['nome_Completo']
            const date = new Date(data['dataDeNascimento'])
            const formattedDate = `${date.getDate().toString().padStart(2, '0')}/${(date.getMonth() + 1).toString().padStart(2, '0')}/${date.getFullYear()}`
            $DataNascimento.value = formattedDate
            $CPF.value = data['cpf']
            $("#optionStatus").val(data['status_Cadastro']);
        },
        error: function (data) {
            alert("Error: " + data)
        }
    })

    let btnAlterar = document.querySelector("#btnAlterar")
    btnAlterar.addEventListener('click', EditarAluno)

    function EditarAluno() {
        let $Status = StatusOption.options[StatusOption.selectedIndex].value;
        let $EscolaOption = document.getElementById('optionEscola');
        let $TurmaOption = document.getElementById('optionTurma');
        let $Escola, $Turma;

        if ($EscolaOption.selectedIndex > 0) {
            $Escola = $EscolaOption.options[$EscolaOption.selectedIndex].value;
        } else {
            $Escola = "";
        }

        if ($TurmaOption.selectedIndex > 0) {
            $Turma = $TurmaOption.options[$TurmaOption.selectedIndex].value;
        } else {
            $Turma = "";
        }

        let objData = { "CPF": CPF, "StatusCadastro": $Status, "Turma": $Turma, "Escola": $Escola }


        console.log(objData)
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

        let objData = { "CPF": CPF }
        console.log(objData)

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

function numberInputElementCreator(element, id, elementPai, text, value) {
    let newElement = document.createElement(element);
    newElement.id = id;
    newElement.textContent = text;
    newElement.value = value;
    document.querySelector(`#${elementPai}`).appendChild(newElement);
}
