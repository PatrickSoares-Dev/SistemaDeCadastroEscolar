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
}

