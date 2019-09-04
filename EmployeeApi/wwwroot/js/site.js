const uri = "api/employee"
let employees = null

function getCount(data) {
    const el = $("#counter")
    let name = "employee"

    if (data) {
        if (data > 1)
            name = "employees"

        el.text(data + " " + name)
    } else
        el.text("No " + name)
}

$(document).ready(() => {
    getData()
})

function getData() {
    $.ajax({
        type: "GET",
        url: uri,
        cache: false,
        success: (data) => {
            const tBody = $("#employees")

            $(tBody).empty()

            getCount(data.length)

            $.each(data, (key, employee) => {
                const tr = $("<td></tr>")
                .append($("<td></td>").text(employee.firstname))
                .append($("<td></td>").text(employee.lastname))
                .append($("<td></td>").text(employee.email))
                .append($("<td></td>").text(employee.cellphone))
                .append(
                    $("<td></td>").append(
                        $("<button>Edit</button>").on("click", () => {
                            editEmployee(employee.id)
                        })
                    )
                )
                .append(
                    $("<td></td>").append(
                        $("<button>Delete</button>").on("click", () => {
                            deleteEmployee(employee.id)
                        })
                    )
                )
                tr.appendTo(tBody)
            })
            employees = data
        }
    })
}

function addEmployee() {
    const employee = {
        firstname: $("#add-firstname").val(),
        lastname: $("#add-lastname").val(),
        email: $("#add-email").val(),
        cellphone: $("#add-cellphone").val()
    }

    $.ajax({
        type: "POST",
        accepts: "application/json",
        url: uri,
        contentType: "application/json",
        data: JSON.stringify(employee),
        error: (jqXHR, textStatus, errorThrown) => {
            alert("Something went wrong!")
        },
        success: (result) => {
            getData()
            $("#add-firstname").val("")
            $("#add-lastname").val("")
            $("#add-email").val("")
            $("#add-cellphone").val("")
        }
    })
}

function deleteEmployee(id) {
    $.ajax({
        url: uri + "/" + id,
        type: "DELETE",
        success: (result) => {
            getData()
        }
    })
}

function editEmployee(id) {
    $.each(employees, (key, employee) => {
        if (employee.id === id) {
            $("#edit-firstname").val(employee.firstname)
            $("#edit-lastname").val(employee.lastname)
            $("#edit-email").val(employee.email)
            $("#edit-cellphone").val(employee.cellphone)
        }
    })
    $("#spoiler").css({ display: "block" })
}

$(".edit-form").on("submit", () => {
    const employee = {
        firstname: $("edit-firstname").val(),
        lastname: $("edit-lastname").val(),
        email: $("edit-email").val(),
        cellphone: $("edit-cellphone").val(),
        id: $("edit-id").val()
    }

    $.ajax({
        url: uri + "/" + $("#edit-id").val(),
        type: "PUT",
        accepts: "application/json",
        contentType: "application/json",
        data: JSON.stringify(employee),
        success: (result) => {
            getData()
        }
    })

    closeInput()
    return false
})

function closeInput() {
    $("#spoiler").css({ display: "none" })
}