$(document).ready(function () {
    function formatarData(data) {
        if (data === null) return "Sem Data";
        var dataObj = new Date(data);
        var dia = String(dataObj.getDate()).padStart(2, '0');
        var mes = String(dataObj.getMonth() + 1).padStart(2, '0'); // Janeiro é 0!
        var ano = dataObj.getFullYear();
        return `${dia}/${mes}/${ano}`;
    }

    $.ajax({
        url: 'https://localhost:44330/api/v1/tasks',
        type: 'GET',
        success: function (data) {
            $('tbody').empty();
            var contador = 1;
            data.forEach(function (campos) {
                if (campos.isComplete == false) {
                    var ISCOMPLETE = 'Não';
                }
                else {
                    var ISCOMPLETE = "Sim";
                }

                if (campos.prioridade == 0) {
                    var PRIORIDADE = "Baixa";
                }
                else if (campos.prioridade == 1) {
                    var PRIORIDADE = "Moderada";
                }
                else {
                    var PRIORIDADE = "Alta";
                }

                var DATALIMITE = (campos.dataLimite == null) ? "Sem Data" : formatarData(campos.dataLimite)

                $('tbody').append('<tr style="height: 50px">' +
                    '<td>' + contador + '</td>' +
                    '<td>' + campos.nome + '</td>' +
                    '<td>' + ISCOMPLETE + '</td>' +
                    '<td>' + DATALIMITE + '</td>' +
                    '<td>' + PRIORIDADE + '</td>' +
                    '<td><button type="button" class="btn btn-primary btnModal" data-toggle="modal" data-target="#exampleModalCenter" data-id="' + campos.taskId + '">Informações</button><a type="button" role="button" class="btn btn-warning btnModificar" data-id="' + campos.taskId + '">Modificar</a><a type="button" role="button" class="btn btn-danger btnDeletar" data-id="' + campos.taskId + '">Deletar</a></td>' +
                    '</tr>'
                )
                contador++;
            })
            $('.btnModal').on('click', function () {
                var TASKID = $(this).attr('data-id');
                $.ajax({
                    url: 'https://localhost:44330/api/v1/tasks/' + TASKID,
                    type: 'GET',
                    success: function (data) {
                        if (data.isComplete == false) {
                            var ISCOMPLETE = 'Não';
                        }
                        else {
                            var ISCOMPLETE = 'Sim'
                        }

                        if (data.prioridade == 0) {
                            var PRIORIDADE = "Baixa";
                        }
                        else if (data.prioridade == 1) {
                            var PRIORIDADE = "Moderada";
                        }
                        else {
                            var PRIORIDADE = "Alta";
                        }

                        var DATALIMITE = (data.dataLimite == null) ? "Sem Data" : formatarData(data.dataLimite)
                        $('.TextoCabecalho').text(`${data.nome}`)
                        $('.modal-body').html('<div style="text-align:center;"><p><b>Descrição: </b>' + data.descricao + '</p>' +
                            '<p><b>Datas: </b>' + formatarData(data.dataCriacao) + ' -- ' + DATALIMITE + '</p>' +
                            '<p><b>Está Concluída? </b>' + ISCOMPLETE + '</p>' +
                            '<p><b>Prioridade: </b>' + PRIORIDADE + '</p></div>' 
                        )
                    }, 
                    error: function (error) {
                        throw error
                    }

                })
            })

            $('.btnModificar').on('click', function (event) {
                var taskID = $(this).attr('data-id');
                window.location.href = 'https://localhost:44381/Task/Update?id=' + taskID;
            })

            $('.btnDeletar').on('click', function (event) {
                var task = $(this).attr('data-id');
                window.location.href = 'https://localhost:44381/Task/Delete?id=' + task;
            })
        },
        error: function (error) {
            throw error;
        }
    })
})


    

