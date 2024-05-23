$(document).ready(function(){
    $.ajax({
        url: 'https://localhost:44330/api/v1/tasks',
        type: 'GET',
        success: function (data) {
            $('tbody').empty();
            data.forEach(function (campos) {

                if (campos.isComplete == false) {
                    var ISCOMPLETE = 'Não';
                }
                else {
                    var ISCOMPLETE = campos.isComplete
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

                var DATALIMITE = (campos.dataLimite == null) ? "Sem Data" : campos.dataLimite

                $('tbody').append('<tr>' +
                    '<td>' + campos.taskId + '</td>' +
                    '<td>' + campos.nome + '</td>' +
                    '<td>' + ISCOMPLETE + '</td>' +
                    '<td>' + DATALIMITE + '</td>' +
                    '<td>' + PRIORIDADE + '</td>' +
                    '<td><button type="button" class="btn btn-primary btnModal" data-toggle="modal" data-target="#exampleModalCenter" data-id="' + campos.taskId + '">Informações</button></td>' +
                    '</tr>'
                )
            })
            $('.btnModal').on('click', function () {
                var TASKID = $(this).attr('data-id');
                console.log(TASKID)
                $.ajax({
                    url: 'https://localhost:44330/api/v1/tasks/' + TASKID,
                    type: 'GET',
                    success: function (data) {
                        if (data.isComplete == false) {
                            var ISCOMPLETE = 'Não';
                        }
                        else {
                            var ISCOMPLETE = data.isComplete
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

                        var DATALIMITE = (data.dataLimite == null) ? "Sem Data" : data.dataLimite
                        $('.TextoCabecalho').text(`${data.nome}`)
                        $('.modal-body').html('<div style="text-align:center;"></div><p><b>Descrição: </b>' + data.descricao + '</p>' +
                            '<p><b>Datas: </b>' + data.dataCriacao + ' -- ' + DATALIMITE + '</p>' +
                            '<p><b>Está Concluída? </b>' + ISCOMPLETE + '</p>' +
                            '<p><b>Prioridade: </b>' + PRIORIDADE + '</p></div>' 
                        )
                    },
                    error: function (error) {
                        throw error
                    }

                })
            })
        },
        error: function (error) {
            throw error;
        }
    })
})


    

