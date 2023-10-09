// Get the modal
$(document).ready(function () {
    var pagina = window.location.pathname;

    //console.log(pagina);
    $('#pagina').val(pagina);

    $(".disabled").prop("disabled", true);

    if (pagina.indexOf("/clases") !== -1) {
        var skills_modal_pasivas = $(".skills_modal_pasivas");
        var skills_modal_activas = $(".skills_modal_activas");

        $('.btn_skills_sugeridas_pasivas').click(function () {
            $(this).parent().find(".skills_modal_pasivas").show();
        });
        $('.btn_skills_sugeridas_activas').click(function () {
            $(this).parent().find(".skills_modal_activas").show();
        });
        $('.close').click(function () {
            skills_modal_pasivas.hide();
            skills_modal_activas.hide();
        });
    }
    
    if (pagina.indexOf("/personajes/Details/") !== -1) {
        var skills_modal = document.getElementById("skills_modal");
        var inventario_modal = document.getElementById("inventario_modal");
        var casco_modal = document.getElementById("casco_modal");
        var pechera_modal = document.getElementById("pechera_modal");
        var arma_modal = document.getElementById("arma_modal");
        var escudo_modal = document.getElementById("escudo_modal");
        var guantes_modal = document.getElementById("guantes_modal");
        var botas_modal = document.getElementById("botas_modal");
        var transferencias_modal = document.getElementById("transferencias_modal");
        var mascotas_modal = document.getElementById("mascotas_modal");

        // Get the button that opens the modal
        var btn_inventario = document.getElementById("btn_inventario");
        var btn_skills = document.getElementById("btn_skills");
        var btn_cascos = document.getElementById("btn_cascos");
        var btn_pecheras = document.getElementById("btn_pecheras");
        var btn_armas = document.getElementById("btn_armas");
        var btn_escudos = document.getElementById("btn_escudos");
        var btn_guantes = document.getElementById("btn_guantes");
        var btn_botas = document.getElementById("btn_botas");
        var btn_economia = document.getElementById("btn_economia");
        var btn_menu_mascotas = document.getElementById("btn_menu_mascotas");
        

        // Get the <span> element that closes the modal
        //var span = document.getElementsByClassName("close");

        // When the user clicks on the button, open the modal
        btn_skills.onclick = function () {
            skills_modal.style.display = "block";
        }

        btn_cascos.onclick = function () {
            casco_modal.style.display = "block";
        }

        btn_inventario.onclick = function () {
            inventario_modal.style.display = "block";
        }

        btn_pecheras.onclick = function () {
            pechera_modal.style.display = "block";
        }

        btn_armas.onclick = function () {
            arma_modal.style.display = "block";
        }

        btn_escudos.onclick = function () {
            escudo_modal.style.display = "block";
        }

        btn_guantes.onclick = function () {
            guantes_modal.style.display = "block";
        }

        btn_botas.onclick = function () {
            botas_modal.style.display = "block";
        }

        btn_menu_mascotas.onclick = function () {
            mascotas_modal.style.display = "block";
        }

        btn_economia.onclick = function () {
            transferencias_modal.style.display = "block";
        }


        //eventos acordeon
        $(".accordion").click(function () {
            var item_nombre = $(this).text();
            $(".panel").each(function () {
                var panel = $(this);
                var equipado = $(this).attr('item_nombre');
                if (equipado == item_nombre) {
                    panel.toggle();
                }
            });
        });

        $(".popup").hide();

        $(".fila_x_mascota").click(function () {
            var id = $(this).find("#mascota_id").val();
            $('.popup').show();
            var pagina = "/mascotas/Details/" + id;
            $('#mascota_detalle').attr('src', pagina);
        });

      
        $('.close').click(function () {
            skills_modal.style.display = "none";
            inventario_modal.style.display = "none";
            casco_modal.style.display = "none";
            pechera_modal.style.display = "none";
            arma_modal.style.display = "none";
            escudo_modal.style.display = "none";
            guantes_modal.style.display = "none";
            botas_modal.style.display = "none";
            transferencias_modal.style.display = "none";
            mascotas_modal.style.display = "none";
            $('.popup').hide();
        });

        // When the user clicks anywhere outside of the modal, close it
        window.onclick = function (event) {
            if (event.target == skills_modal) {
                skills_modal.style.display = "none";
            }
            if (event.target == inventario_modal) {
                inventario_modal.style.display = "none";
            }
            if (event.target == casco_modal) {
                casco_modal.style.display = "none";
            }
            if (event.target == pechera_modal) {
                pechera_modal.style.display = "none";
            }
            if (event.target == arma_modal) {
                arma_modal.style.display = "none";
            }
            if (event.target == escudo_modal) {
                escudo_modal.style.display = "none";
            }
            if (event.target == guantes_modal) {
                guantes_modal.style.display = "none";
            }
            if (event.target == botas_modal) {
                botas_modal.style.display = "none";
            }
            if (event.target == transferencias_modal) {
                transferencias_modal.style.display = "none";
            }
            if (event.target == mascotas_modal) {
                mascotas_modal.style.display = "none";
            }

        }

        //eventos barras de vida y mana
        var vida_max = $('#vida_max').val();
        var vida_actual = $('#vida_actual').val();

        var penalizacion_peso = $("#penalizacion_peso").val();

        var mochila_equipada = $("#mochila_equipada").val();

        $('#btn_enviar_economia').click(function () {
            var oro = parseInt($("#oro_trans").val());
            var mi_pj = $("#personaje_id").val();
            var pj_a_transferir = $("#listado_transferencias").val();
            var oro_disponible = parseInt($("#oro_disponible").val());
            var plata = parseInt($("#plata_trans").val());
            var plata_disponible = parseInt($("#plata_disponible").val());
            var cobre = parseInt($("#cobre_trans").val());
            var cobre_disponible = parseInt($("#cobre_disponible").val());
            var alertar = false;
            if (oro > oro_disponible) {
                alertar = true;
            }
            if (plata > plata_disponible) {
                alertar = true;
            }
            if (cobre > cobre_disponible) {
                alertar = true;
            }
            if (alertar) {
                alert("Fondos insuficientes!!!");
            } else {
                $.post("/personajes/recibir_dinero?id_pj=" + pj_a_transferir + "&oro=" + oro + "&plata=" + plata + "&cobre=" + cobre);
                $.post("/personajes/dar_dinero?id_pj=" + mi_pj + "&oro=" + oro + "&plata=" + plata + "&cobre=" + cobre);
                transferencias_modal.style.display = "none";
            }
        });

        if (mochila_equipada == "True") {
            $("#peso_mochila_tirada").hide();
            $("#peso_mochila").show();
        } else {
            $("#peso_mochila_tirada").show();
            $("#peso_mochila").hide();
        }

        if (penalizacion_peso != 0) {
            $("#velocidad_actual").removeClass();
            $("#velocidad_actual").addClass("div_barra_vel_penalizada");
        }

        $('.equipado_mochila_check').change(function () {
            var id_pj = $(this).attr('id_pj');
            $.post("/personajes/equip_un_mochila?id_pj=" + id_pj);
            //location.reload(false);
        });


        var porcentaje_vida = (vida_actual * 100) / vida_max;
        $('#barra_actual_vida').width(porcentaje_vida + '%');

        var energia_max = $('#energia_max').val();
        var energia_actual = $('#energia_actual').val();

        var porcentaje_energia = (energia_actual * 100) / energia_max;
        $('#barra_actual_energia').width(porcentaje_energia + '%');

        //eventos calculo de equipo

        //casco
        var casco_atk = 0;
        $('#tabla_cascos td[equipado="0"]').each(function () {
            var equipado = $(this).find('input').prop('checked');
            if (equipado) {
                casco_atk += parseFloat($(this).closest('tr').find('td:nth-child(8)').text());
            }
        });
        var casco_mag_atk = 0;
        $('#tabla_cascos td[equipado="0"]').each(function () {
            var equipado = $(this).find('input').prop('checked');
            if (equipado) {
                casco_mag_atk += parseFloat($(this).closest('tr').find('td:nth-child(9)').text());
            }
        });
        var casco_def = 0;
        $('#tabla_cascos td[equipado="0"]').each(function () {
            var equipado = $(this).find('input').prop('checked');
            if (equipado) {
                casco_def += parseFloat($(this).closest('tr').find('td:nth-child(10)').text());
            }
        });
        var casco_mag_def = 0;
        $('#tabla_cascos td[equipado="0"]').each(function () {
            var equipado = $(this).find('input').prop('checked');
            if (equipado) {
                casco_mag_def += parseFloat($(this).closest('tr').find('td:nth-child(11)').text());
            }
        });
        //console.log(casco_atk);
        $('#casco_atk').val(casco_atk);
        $('#casco_mag_atk').val(casco_mag_atk);
        $('#casco_def').val(casco_def);
        $('#casco_mag_def').val(casco_mag_def);

        //inventario
        var mochila_atk = 0;
        $('#tabla_mochila td[equipado="0"]').each(function () {
            var equipado = $(this).find('input').prop('checked');
            if (equipado) {
                mochila_atk += parseFloat($(this).closest('tr').find('td:nth-child(8)').text());
            }
        });
        var mochila_mag_atk = 0;
        $('#tabla_mochila td[equipado="0"]').each(function () {
            var equipado = $(this).find('input').prop('checked');
            if (equipado) {
                mochila_mag_atk += parseFloat($(this).closest('tr').find('td:nth-child(9)').text());
            }
        });
        var mochila_def = 0;
        $('#tabla_mochila td[equipado="0"]').each(function () {
            var equipado = $(this).find('input').prop('checked');
            if (equipado) {
                mochila_def += parseFloat($(this).closest('tr').find('td:nth-child(10)').text());
            }
        });
        var mochila_mag_def = 0;
        $('#tabla_mochila td[equipado="0"]').each(function () {
            var equipado = $(this).find('input').prop('checked');
            if (equipado) {
                mochila_mag_def += parseFloat($(this).closest('tr').find('td:nth-child(11)').text());
            }
        });
        $('#mochila_atk').val(mochila_atk);
        $('#mochila_mag_atk').val(mochila_mag_atk);
        $('#mochila_def').val(mochila_def);
        $('#mochila_mag_def').val(mochila_mag_def);

        //pecheras
        var pechera_atk = 0;
        $('#tabla_pecheras td[equipado="0"]').each(function () {
            var equipado = $(this).find('input').prop('checked');
            if (equipado) {
                pechera_atk += parseFloat($(this).closest('tr').find('td:nth-child(8)').text());
            }
        });
        var pechera_mag_atk = 0;
        $('#tabla_pecheras td[equipado="0"]').each(function () {
            var equipado = $(this).find('input').prop('checked');
            if (equipado) {
                pechera_mag_atk += parseFloat($(this).closest('tr').find('td:nth-child(9)').text());
            }
        });
        var pechera_def = 0;
        $('#tabla_pecheras td[equipado="0"]').each(function () {
            var equipado = $(this).find('input').prop('checked');
            if (equipado) {
                pechera_def += parseFloat($(this).closest('tr').find('td:nth-child(10)').text());
            }
        });
        var pechera_mag_def = 0;
        $('#tabla_pecheras td[equipado="0"]').each(function () {
            var equipado = $(this).find('input').prop('checked');
            if (equipado) {
                pechera_mag_def += parseFloat($(this).closest('tr').find('td:nth-child(11)').text());
            }
        });
        $('#pechera_atk').val(pechera_atk);
        $('#pechera_mag_atk').val(pechera_mag_atk);
        $('#pechera_def').val(pechera_def);
        $('#pechera_mag_def').val(pechera_mag_def);

        //armas
        var arma_atk = 0;
        $('#tabla_armas td[equipado="0"]').each(function () {
            var equipado = $(this).find('input').prop('checked');
            if (equipado) {
                arma_atk += parseFloat($(this).closest('tr').find('td:nth-child(8)').text());
            }
        });
        var arma_mag_atk = 0;
        $('#tabla_armas td[equipado="0"]').each(function () {
            var equipado = $(this).find('input').prop('checked');
            if (equipado) {
                arma_mag_atk += parseFloat($(this).closest('tr').find('td:nth-child(9)').text());
            }
        });
        var arma_def = 0;
        $('#tabla_armas td[equipado="0"]').each(function () {
            var equipado = $(this).find('input').prop('checked');
            if (equipado) {
                arma_def += parseFloat($(this).closest('tr').find('td:nth-child(10)').text());
            }
        });
        var arma_mag_def = 0;
        $('#tabla_armas td[equipado="0"]').each(function () {
            var equipado = $(this).find('input').prop('checked');
            if (equipado) {
                arma_mag_def += parseFloat($(this).closest('tr').find('td:nth-child(11)').text());
            }
        });
        $('#arma_atk').val(arma_atk);
        $('#arma_mag_atk').val(arma_mag_atk);
        $('#arma_def').val(arma_def);
        $('#arma_mag_def').val(arma_mag_def);

        //escudos
        var escudo_atk = 0;
        $('#tabla_escudos td[equipado="0"]').each(function () {
            var equipado = $(this).find('input').prop('checked');
            if (equipado) {
                escudo_atk += parseFloat($(this).closest('tr').find('td:nth-child(8)').text());
            }
        });
        var escudo_mag_atk = 0;
        $('#tabla_escudos td[equipado="0"]').each(function () {
            var equipado = $(this).find('input').prop('checked');
            if (equipado) {
                escudo_mag_atk += parseFloat($(this).closest('tr').find('td:nth-child(9)').text());
            }
        });
        var escudo_def = 0;
        $('#tabla_escudos td[equipado="0"]').each(function () {
            var equipado = $(this).find('input').prop('checked');
            if (equipado) {
                escudo_def += parseFloat($(this).closest('tr').find('td:nth-child(10)').text());
            }
        });
        var escudo_mag_def = 0;
        $('#tabla_escudos td[equipado="0"]').each(function () {
            var equipado = $(this).find('input').prop('checked');
            if (equipado) {
                escudo_mag_def += parseFloat($(this).closest('tr').find('td:nth-child(11)').text());
            }
        });
        $('#escudo_atk').val(escudo_atk);
        $('#escudo_mag_atk').val(escudo_mag_atk);
        $('#escudo_def').val(escudo_def);
        $('#escudo_mag_def').val(escudo_mag_def);

        //guantes
        var guante_atk = 0;
        $('#tabla_guantes td[equipado="0"]').each(function () {
            var equipado = $(this).find('input').prop('checked');
            if (equipado) {
                guante_atk += parseFloat($(this).closest('tr').find('td:nth-child(8)').text());
            }
        });
        var guante_mag_atk = 0;
        $('#tabla_guantes td[equipado="0"]').each(function () {
            var equipado = $(this).find('input').prop('checked');
            if (equipado) {
                guante_mag_atk += parseFloat($(this).closest('tr').find('td:nth-child(9)').text());
            }
        });
        var guante_def = 0;
        $('#tabla_guantes td[equipado="0"]').each(function () {
            var equipado = $(this).find('input').prop('checked');
            if (equipado) {
                guante_def += parseFloat($(this).closest('tr').find('td:nth-child(10)').text());
            }
        });
        var guante_mag_def = 0;
        $('#tabla_guantes td[equipado="0"]').each(function () {
            var equipado = $(this).find('input').prop('checked');
            if (equipado) {
                guante_mag_def += parseFloat($(this).closest('tr').find('td:nth-child(11)').text());
            }
        });
        $('#guante_atk').val(guante_atk);
        $('#guante_mag_atk').val(guante_mag_atk);
        $('#guante_def').val(guante_def);
        $('#guante_mag_def').val(guante_mag_def);

        //botas
        var botas_atk = 0;
        $('#tabla_botas td[equipado="0"]').each(function () {
            var equipado = $(this).find('input').prop('checked');
            if (equipado) {
                botas_atk += parseFloat($(this).closest('tr').find('td:nth-child(8)').text());
            }
        });
        var botas_mag_atk = 0;
        $('#tabla_botas td[equipado="0"]').each(function () {
            var equipado = $(this).find('input').prop('checked');
            if (equipado) {
                botas_mag_atk += parseFloat($(this).closest('tr').find('td:nth-child(9)').text());
            }
        });
        var botas_def = 0;
        $('#tabla_botas td[equipado="0"]').each(function () {
            var equipado = $(this).find('input').prop('checked');
            if (equipado) {
                botas_def += parseFloat($(this).closest('tr').find('td:nth-child(10)').text());
            }
        });
        var botas_mag_def = 0;
        $('#tabla_botas td[equipado="0"]').each(function () {
            var equipado = $(this).find('input').prop('checked');
            if (equipado) {
                botas_mag_def += parseFloat($(this).closest('tr').find('td:nth-child(11)').text());
            }
        });
        $('#botas_atk').val(botas_atk);
        $('#botas_mag_atk').val(botas_mag_atk);
        $('#botas_def').val(botas_def);
        $('#botas_mag_def').val(botas_mag_def);

        //asiginacion de hiddens de equipo
        //atk
        $('#atk_equipo_span').text(casco_atk + mochila_atk + pechera_atk + arma_atk + escudo_atk + guante_atk + botas_atk);
        $('#atk_equipo').val(casco_atk + mochila_atk + pechera_atk + arma_atk + escudo_atk + guante_atk + botas_atk);
        $('#atk_total').val(parseFloat($('#atk_natural').val()) + parseFloat($('#atk_equipo').val()));
        //mag_atk
        $('#mag_atk_equipo_span').text(casco_mag_atk + mochila_mag_atk + pechera_mag_atk + arma_mag_atk + escudo_mag_atk + guante_mag_atk + botas_mag_atk);
        $('#mag_atk_equipo').val(casco_mag_atk + mochila_mag_atk + pechera_mag_atk + arma_mag_atk + escudo_mag_atk + guante_mag_atk + botas_mag_atk);
        $('#mag_atk_total').val(parseFloat($('#mag_atk_natural').val()) + parseFloat($('#mag_atk_equipo').val()));
        //def
        $('#armor_equipo_span').text(casco_def + mochila_def + pechera_def + arma_def + escudo_def + guante_def + botas_def);
        $('#armor_equipo').val(casco_def + mochila_def + pechera_def + arma_def + escudo_def + guante_def + botas_def);
        $('#armor_total').val(parseFloat($('#armor_natural').val()) + parseFloat($('#armor_equipo').val()));
        //mag_def
        $('#mr_equipo_span').text(casco_mag_def + mochila_mag_def + pechera_mag_def + arma_mag_def + escudo_mag_def + guante_mag_def + botas_mag_def);
        $('#mr_equipo').val(casco_mag_def + mochila_mag_def + pechera_mag_def + arma_mag_def + escudo_mag_def + guante_mag_def + botas_mag_def);
        $('#mr_total').val(parseFloat($('#mr_natural').val()) + parseFloat($('#mr_equipo').val()));

        $('.equipado_check').change(function () {
            var id_asoc = $(this).attr('id_asoc');
            var cambio = { id_asoc: id_asoc };
            $.post("/personajes/equip_un", cambio);
            //location.reload(false);
        });

        //Uso de Skills
        $('.btn_skill_use').click(function () {
            //alert($(this).attr("id_asoc"));
            var asoc_id = parseInt($(this).attr("id_asoc"));
            var skillUp = { id: asoc_id };

            $.post("/personajes/SkillUse", skillUp);
            //location.reload(true);
        });

        //leveleo:
        var stats = parseInt($('#stats').val());
        if (stats != 0) {
            $(".lvl").show();
        } else {
            $(".lvl").hide();
        }
        $(".buff").hide();

        $('#btn_buffo').click(function () {
            $('#btn_buffo').hide();
            $(".buff").show();
        });

        
        $('#btn_ok_buff').click(function () {
            var valor_fuerza = parseInt($('#fuerza_buff').val());
            var valor_inteligencia = parseInt($('#inteligencia_buff').val());
            var valor_sabiduria = parseInt($('#sabiduria_buff').val());
            var valor_agilidad = parseInt($('#agilidad_buff').val());
            var valor_resistencia = parseInt($('#resistencia_buff').val());
            var valor_velocidad = parseInt($('#velocidad_buff').val());
            var personaje_id = parseInt($('#personaje_id').val());
            var level_up = {id: personaje_id, fuerza: valor_fuerza,inteligencia: valor_inteligencia,sabiduria: valor_sabiduria,agilidad: valor_agilidad,resistencia: valor_resistencia,velocidad: valor_velocidad};
        
            $.post("/personajes/BuffUp", level_up);

            $(".buff").hide();

            $('#btn_buffo').show();

            //location.reload(true);
        });

        $('#btn_ok').click(function () {
            var valor_fuerza = parseInt($('#fuerza_lvl').val());
            var valor_inteligencia = parseInt($('#inteligencia_lvl').val());
            var valor_sabiduria = parseInt($('#sabiduria_lvl').val());
            var valor_agilidad = parseInt($('#agilidad_lvl').val());
            var valor_resistencia = parseInt($('#resistencia_lvl').val());
            var valor_velocidad = parseInt($('#velocidad_lvl').val());
            var personaje_id = parseInt($('#personaje_id').val());
            var level_up = {id: personaje_id, fuerza: valor_fuerza,inteligencia: valor_inteligencia,sabiduria: valor_sabiduria,agilidad: valor_agilidad,resistencia: valor_resistencia,velocidad: valor_velocidad};
        
            $.post("/personajes/LevelUp", level_up);

            if (stats == 0) {
                $(".lvl").hide();
            }

            //location.reload(true);
        });

        $('#btn_fuerza_mas').click(function () {
            var valor_viejo = parseInt($('#fuerza_lvl').val());
            if (stats > 0) {
                stats = stats - 1;
                valor_viejo = valor_viejo + 1;
                $('#stats').val(stats);
                $('#fuerza_lvl').val(valor_viejo);
            }
        });

        $('#btn_fuerza_menos').click(function () {
            var valor_viejo = parseInt($('#fuerza_lvl').val());
            if (valor_viejo > 0) {
                stats = stats + 1;
                valor_viejo = valor_viejo - 1;
                $('#stats').val(stats);
                $('#fuerza_lvl').val(valor_viejo);
            }
        });

        $('#btn_fuerza_mas_buff').click(function () {
            var valor_viejo = parseInt($('#fuerza_buff').val());
            valor_viejo = valor_viejo + 1;
            $('#fuerza_buff').val(valor_viejo);
        });

        $('#btn_fuerza_menos_buff').click(function () {
            var valor_viejo = parseInt($('#fuerza_buff').val());
            valor_viejo = valor_viejo - 1;
            $('#fuerza_buff').val(valor_viejo);
        });

        $('#btn_inteligencia_mas').click(function () {
            var valor_viejo = parseInt($('#inteligencia_lvl').val());
            if (stats > 0) {
                stats = stats - 1;
                valor_viejo = valor_viejo + 1;
                $('#stats').val(stats);
                $('#inteligencia_lvl').val(valor_viejo);
            }
        });

        $('#btn_inteligencia_menos').click(function () {
            var valor_viejo = parseInt($('#inteligencia_lvl').val());
            if (valor_viejo > 0) {
                stats = stats + 1;
                valor_viejo = valor_viejo - 1;
                $('#stats').val(stats);
                $('#inteligencia_lvl').val(valor_viejo);
            }
        });

        $('#btn_inteligencia_mas_buff').click(function () {
            var valor_viejo = parseInt($('#inteligencia_buff').val());
            valor_viejo = valor_viejo + 1;
            $('#inteligencia_buff').val(valor_viejo);
        });

        $('#btn_inteligencia_menos_buff').click(function () {
            var valor_viejo = parseInt($('#inteligencia_buff').val());
            valor_viejo = valor_viejo - 1;
            $('#inteligencia_buff').val(valor_viejo);
        });

        $('#btn_sabiduria_mas').click(function () {
            var valor_viejo = parseInt($('#sabiduria_lvl').val());
            if (stats > 0) {
                stats = stats - 1;
                valor_viejo = valor_viejo + 1;
                $('#stats').val(stats);
                $('#sabiduria_lvl').val(valor_viejo);
            }
        });

        $('#btn_sabiduria_menos').click(function () {
            var valor_viejo = parseInt($('#sabiduria_lvl').val());
            if (valor_viejo > 0) {
                stats = stats + 1;
                valor_viejo = valor_viejo - 1;
                $('#stats').val(stats);
                $('#sabiduria_lvl').val(valor_viejo);
            }
        });

        $('#btn_sabiduria_mas_buff').click(function () {
            var valor_viejo = parseInt($('#sabiduria_buff').val());
            valor_viejo = valor_viejo + 1;
            $('#sabiduria_buff').val(valor_viejo);
        });

        $('#btn_sabiduria_menos_buff').click(function () {
            var valor_viejo = parseInt($('#sabiduria_buff').val());
            valor_viejo = valor_viejo - 1;
            $('#sabiduria_buff').val(valor_viejo);
        });

        $('#btn_agilidad_mas').click(function () {
            var valor_viejo = parseInt($('#agilidad_lvl').val());
            if (stats > 0) {
                stats = stats - 1;
                valor_viejo = valor_viejo + 1;
                $('#stats').val(stats);
                $('#agilidad_lvl').val(valor_viejo);
            }
        });

        $('#btn_agilidad_menos').click(function () {
            var valor_viejo = parseInt($('#agilidad_lvl').val());
            if (valor_viejo > 0) {
                stats = stats + 1;
                valor_viejo = valor_viejo - 1;
                $('#stats').val(stats);
                $('#agilidad_lvl').val(valor_viejo);
            }
        });

        $('#btn_agilidad_mas_buff').click(function () {
            var valor_viejo = parseInt($('#agilidad_buff').val());
            valor_viejo = valor_viejo + 1;
            $('#agilidad_buff').val(valor_viejo);
        });

        $('#btn_agilidad_menos_buff').click(function () {
            var valor_viejo = parseInt($('#agilidad_buff').val());
            valor_viejo = valor_viejo - 1;
            $('#agilidad_buff').val(valor_viejo);
        });

        $('#btn_resistencia_mas').click(function () {
            var valor_viejo = parseInt($('#resistencia_lvl').val());
            if (stats > 0) {
                stats = stats - 1;
                valor_viejo = valor_viejo + 1;
                $('#stats').val(stats);
                $('#resistencia_lvl').val(valor_viejo);
            }
        });

        $('#btn_resistencia_menos').click(function () {
            var valor_viejo = parseInt($('#resistencia_lvl').val());
            if (valor_viejo > 0) {
                stats = stats + 1;
                valor_viejo = valor_viejo - 1;
                $('#stats').val(stats);
                $('#resistencia_lvl').val(valor_viejo);
            }
        });

        $('#btn_resistencia_mas_buff').click(function () {
            var valor_viejo = parseInt($('#resistencia_buff').val());
            valor_viejo = valor_viejo + 1;
            $('#resistencia_buff').val(valor_viejo);
        });

        $('#btn_resistencia_menos_buff').click(function () {
            var valor_viejo = parseInt($('#resistencia_buff').val());
            valor_viejo = valor_viejo - 1;
            $('#resistencia_buff').val(valor_viejo);
        });

        $('#btn_velocidad_mas').click(function () {
            var valor_viejo = parseInt($('#velocidad_lvl').val());
            if (stats > 0) {
                stats = stats - 1;
                valor_viejo = valor_viejo + 1;
                $('#stats').val(stats);
                $('#velocidad_lvl').val(valor_viejo);
            }
        });

        $('#btn_velocidad_menos').click(function () {
            var valor_viejo = parseInt($('#velocidad_lvl').val());
            if (valor_viejo > 0) {
                stats = stats + 1;
                valor_viejo = valor_viejo - 1;
                $('#stats').val(stats);
                $('#velocidad_lvl').val(valor_viejo);
            }
        });

        $('#btn_velocidad_mas_buff').click(function () {
            var valor_viejo = parseInt($('#velocidad_buff').val());
            valor_viejo = valor_viejo + 1;
            $('#velocidad_buff').val(valor_viejo);
        });

        $('#btn_velocidad_menos_buff').click(function () {
            var valor_viejo = parseInt($('#velocidad_buff').val());
            valor_viejo = valor_viejo - 1;
            $('#velocidad_buff').val(valor_viejo);
        });

    }


    if (pagina.indexOf("/encuentros") !== -1) {
        $(".popup").hide();
        $('#filtro_mon_nombre').on('keyup', function () {
            var tier = $('#tier').val();
            var mon_nombre = $('#filtro_mon_nombre').val();
            $('.filtrado').hide();
            if (tier == 0 && mon_nombre == "") {
                $('.filtrado').show();
            }
            else {
                if (tier != 0) {
                    $('#filtro_mon_encuentros').find('tr[tier="' + tier + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(mon_nombre) > -1; $(this).toggle(condicion); });
                }
                else {
                    $('#filtro_mon_encuentros tr').filter(function () {
                        $(this).toggle($(this).text().toLowerCase().indexOf(mon_nombre) > -1);
                    });
                }
            }
        });
        $('#tier').change(function () {
            var tier = $('#tier').val();
            var mon_nombre = $('#filtro_mon_nombre').val();
            $('.filtrado').hide();
            if (tier == 0 && mon_nombre == "") {
                $('.filtrado').show();
            }
            else {
                if (tier != 0) {
                    $('#filtro_mon_encuentros').find('tr[tier="' + tier + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(mon_nombre) > -1; $(this).toggle(condicion); });
                }
                else {
                    $('#filtro_mon_encuentros tr').filter(function () {
                        $(this).toggle($(this).text().toLowerCase().indexOf(mon_nombre) > -1);
                    });
                }
            }
        });

        $('.mon_seleccion').click(function () {
            var id_mon = $(this).attr("id_mon");
            $('.popup').show();
            var pagina = "/encuentros/Details_mon/" + id_mon.toString();
            $('#ventana').attr('src', pagina);
        });

        $(".close").click(function () {
            $(this).parent().hide();
        });

        $('.personaje_seleccion').click(function () {
            var id_pj = $(this).attr("id_pj");
            //alert(id_pj);
            $('.popup').show();
            var pagina = "/encuentros/Details_pj/" + id_pj.toString();
            $('#ventana').attr('src', pagina);
        });

        $('.btn_mon_select').click(function (e) {
            e.preventDefault();
            var id_mon = $(this).attr("id_item");
            var cantidad = $("#cantidad_mon_" + id_mon).val();
            for (var i = 0; i < cantidad; i++){
                $.post("/encuentros/agregar_a_party_mon?id_mon=" + id_mon);
            }
        });

        $('.btn_mon_borrar').click(function (e) {
            e.preventDefault();
            var id_mon = $(this).attr("id_mon");
            $.post("/encuentros/eliminar_de_party_mon?id_mon=" + id_mon);
        });

        $('#id_personaje').append($('<option>', {
            value: 0,
            text: 'Todos'
        }));

        $('#id_personaje').val(0);

        $('#id_personaje').change(function () {
            var id_personaj = $('#id_personaje').val();
            
            var url = "/encuentros/get_atributos_calculadora?id_pj=" + id_personaj;
            /*var id_pj = { id_pj: id_personaj };*/
            //console.log(id_pj);
            $.get(url)
                .done(function (data) {
                    $("#agi_pj").val(data.pj_agi);
                    $("#vel_pj").val(data.pj_vel);
                    $("#danio_pj").val(data.danio);

                });

        });


        $('#boton_impactar_danio').click(function (e) {
            e.preventDefault();
            var id_party_mon = $(this).attr("id_party_mon");
            var es_skill = $('#es_skill').prop('checked');
            var tipo_danio = 0;
            var esquive = $('#esquive').is(":checked");
            var resistencia = $('#resistencia').is(":checked");
            var directo = $('#directo').is(":checked");
            var agi_pj = $("#agi_pj").val();
            var vel_pj = $("#vel_pj").val();
            var danio_pj_basico = $("#danio_pj").val();
            var dado_prec = $("#dado_prec").val();
            var danio_skill = $("#danio_skill").val();
            var es_magico = $('#es_danio_magico').prop('checked');

            if (esquive) {
                tipo_danio = 1;
            }
            if (resistencia) {
                tipo_danio = 2;
            }
            if (directo) {
                tipo_danio = 3;
            }
            
            //alert(id_skill);
            //alert(personaje_id);
            var danio_a_mon = { id_party_mon_id: id_party_mon, es_skill: es_skill, tipo_danio: tipo_danio, agi_pj: agi_pj, vel_pj: vel_pj, danio_pj_basico: danio_pj_basico, dado_prec: dado_prec, danio_skill: danio_skill, es_magico: es_magico};

            $.post("/encuentros/impactar_danio_a_mon", danio_a_mon);

        });

        $('#boton_impactar_danio_pj').click(function (e) {
            e.preventDefault();
            var id_pj = $(this).attr("id_pj");
            var es_skill = $('#es_skill').prop('checked');
            var tipo_danio = 0;
            var esquive = $('#esquive').is(":checked");
            var resistencia = $('#resistencia').is(":checked");
            var directo = $('#directo').is(":checked");
            var tier = $("#tier").val();
            var vel_mon = $("#vel_mon").val();
            var danio_mon_basico = $("#danio_mon").val();
            var dado_prec = $("#dado_prec").val();
            var danio_skill = $("#danio_skill").val();
            var es_magico = $('#es_danio_magico').prop('checked');

            if (esquive) {
                tipo_danio = 1;
            }
            if (resistencia) {
                tipo_danio = 2;
            }
            if (directo) {
                tipo_danio = 3;
            }
            
            //alert(id_skill);
            //alert(personaje_id);
            var danio_a_mon = { id_pj: id_pj, es_skill: es_skill, tipo_danio: tipo_danio, tier: tier, vel_mon: vel_mon, danio_mon_basico: danio_mon_basico, dado_prec: dado_prec, danio_skill: danio_skill, es_magico: es_magico};

            $.post("/encuentros/impactar_danio_a_pj", danio_a_mon);

        });
        
        $('#boton_mana_mon_desc').click(function (e) {
            e.preventDefault();
            var id_party_mon = $(this).attr("id_party_mon");
            var mana_desc = $('#mana_desc').val();
            
            //alert(id_skill);
            //alert(personaje_id);
            var descontar_mana_mon_model = { id_party_mon_id: id_party_mon, mana: mana_desc};

            $.post("/encuentros/descontar_mana", descontar_mana_mon_model);

        });
        

    }

    if (pagina.indexOf("/asoc_personaje_skill") !== -1) {
        if ((pagina.indexOf("/asoc_personaje_skill/Edit/") !== -1) || (pagina.indexOf("/asoc_personaje_skill/Create") !== -1)) {
            $('#filtro_skills_nombre').on('keyup', function () {
                var skill_nivel = $('#skill_nivel').val();
                var skill_alineamiento = $('#skill_alineamiento').val();
                var skill_tipo = $('#skill_tipo').val();
                var skill_texto = $('#filtro_skills_nombre').val().toLowerCase();

                $('.filtrado').hide();

                if (skill_nivel == 0 && skill_alineamiento == 0 && skill_tipo == 0 && skill_texto == "") {
                    $('.filtrado').show();
                } else {
                    if (skill_nivel != 0 && skill_alineamiento == 0 && skill_tipo == 0) {
                        $('#tabla_skills_resumido').find('tr[skill_nivel="' + skill_nivel + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel != 0 && skill_alineamiento != 0 && skill_tipo == 0) {
                        $('#tabla_skills_resumido').find('tr[skill_nivel="' + skill_nivel + '"][skill_alineamiento="' + skill_alineamiento + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel != 0 && skill_alineamiento != 0 && skill_tipo != 0) {
                        $('#tabla_skills_resumido').find('tr[skill_nivel="' + skill_nivel + '"][skill_alineamiento="' + skill_alineamiento + '"][ skill_tipo="' + skill_tipo + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel == 0 && skill_alineamiento != 0 && skill_tipo == 0) {
                        $('#tabla_skills_resumido').find('tr[skill_alineamiento="' + skill_alineamiento + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel == 0 && skill_alineamiento != 0 && skill_tipo != 0) {
                        $('#tabla_skills_resumido').find('tr[skill_alineamiento="' + skill_alineamiento + '"][ skill_tipo="' + skill_tipo + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel == 0 && skill_alineamiento == 0 && skill_tipo != 0) {
                        $('#tabla_skills_resumido').find('tr[skill_tipo="' + skill_tipo + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel != 0 && skill_alineamiento == 0 && skill_tipo != 0) {
                        $('#tabla_skills_resumido').find('tr[skill_nivel="' + skill_nivel + '"][ skill_tipo="' + skill_tipo + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel == 0 && skill_alineamiento == 0 && skill_tipo == 0 && skill_texto != "") {
                        $('#tabla_skills_resumido tr').filter(function () {
                            $(this).toggle($(this).text().toLowerCase().indexOf(skill_texto) > -1);
                        });
                    }

                }
            });

            
            $('#skill_nivel').change(function () {
                var skill_nivel = $('#skill_nivel').val();
                var skill_alineamiento = $('#skill_alineamiento').val();
                var skill_tipo = $('#skill_tipo').val();
                var skill_texto = $('#filtro_skills_nombre').val().toLowerCase();

                $('.filtrado').hide();

                if (skill_nivel == 0 && skill_alineamiento == 0 && skill_tipo == 0 && skill_texto == "") {
                    $('.filtrado').show();
                } else {
                    if (skill_nivel != 0 && skill_alineamiento == 0 && skill_tipo == 0) {
                        $('#tabla_skills_resumido').find('tr[skill_nivel="' + skill_nivel + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel != 0 && skill_alineamiento != 0 && skill_tipo == 0) {
                        $('#tabla_skills_resumido').find('tr[skill_nivel="' + skill_nivel + '"][skill_alineamiento="' + skill_alineamiento + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel != 0 && skill_alineamiento != 0 && skill_tipo != 0) {
                        $('#tabla_skills_resumido').find('tr[skill_nivel="' + skill_nivel + '"][skill_alineamiento="' + skill_alineamiento + '"][ skill_tipo="' + skill_tipo + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel == 0 && skill_alineamiento != 0 && skill_tipo == 0) {
                        $('#tabla_skills_resumido').find('tr[skill_alineamiento="' + skill_alineamiento + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel == 0 && skill_alineamiento != 0 && skill_tipo != 0) {
                        $('#tabla_skills_resumido').find('tr[skill_alineamiento="' + skill_alineamiento + '"][ skill_tipo="' + skill_tipo + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel == 0 && skill_alineamiento == 0 && skill_tipo != 0) {
                        $('#tabla_skills_resumido').find('tr[skill_tipo="' + skill_tipo + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel != 0 && skill_alineamiento == 0 && skill_tipo != 0) {
                        $('#tabla_skills_resumido').find('tr[skill_nivel="' + skill_nivel + '"][ skill_tipo="' + skill_tipo + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel == 0 && skill_alineamiento == 0 && skill_tipo == 0 && skill_texto != "") {
                        $('#tabla_skills_resumido tr').filter(function () {
                            $(this).toggle($(this).text().toLowerCase().indexOf(skill_texto) > -1);
                        });
                    }

                }
            });

            $('#skill_alineamiento').change(function () {
                var skill_nivel = $('#skill_nivel').val();
                var skill_alineamiento = $('#skill_alineamiento').val();
                var skill_tipo = $('#skill_tipo').val();
                var skill_texto = $('#filtro_skills_nombre').val().toLowerCase();

                $('.filtrado').hide();

                if (skill_nivel == 0 && skill_alineamiento == 0 && skill_tipo == 0 && skill_texto == "") {
                    $('.filtrado').show();
                } else {
                    if (skill_nivel != 0 && skill_alineamiento == 0 && skill_tipo == 0) {
                        $('#tabla_skills_resumido').find('tr[skill_nivel="' + skill_nivel + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel != 0 && skill_alineamiento != 0 && skill_tipo == 0) {
                        $('#tabla_skills_resumido').find('tr[skill_nivel="' + skill_nivel + '"][skill_alineamiento="' + skill_alineamiento + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel != 0 && skill_alineamiento != 0 && skill_tipo != 0) {
                        $('#tabla_skills_resumido').find('tr[skill_nivel="' + skill_nivel + '"][skill_alineamiento="' + skill_alineamiento + '"][ skill_tipo="' + skill_tipo + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel == 0 && skill_alineamiento != 0 && skill_tipo == 0) {
                        $('#tabla_skills_resumido').find('tr[skill_alineamiento="' + skill_alineamiento + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel == 0 && skill_alineamiento != 0 && skill_tipo != 0) {
                        $('#tabla_skills_resumido').find('tr[skill_alineamiento="' + skill_alineamiento + '"][ skill_tipo="' + skill_tipo + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel == 0 && skill_alineamiento == 0 && skill_tipo != 0) {
                        $('#tabla_skills_resumido').find('tr[skill_tipo="' + skill_tipo + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel != 0 && skill_alineamiento == 0 && skill_tipo != 0) {
                        $('#tabla_skills_resumido').find('tr[skill_nivel="' + skill_nivel + '"][ skill_tipo="' + skill_tipo + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel == 0 && skill_alineamiento == 0 && skill_tipo == 0 && skill_texto != "") {
                        $('#tabla_skills_resumido tr').filter(function () {
                            $(this).toggle($(this).text().toLowerCase().indexOf(skill_texto) > -1);
                        });
                    }

                }
            });

            $('#skill_tipo').change(function () {
                var skill_nivel = $('#skill_nivel').val();
                var skill_alineamiento = $('#skill_alineamiento').val();
                var skill_tipo = $('#skill_tipo').val();
                var skill_texto = $('#filtro_skills_nombre').val().toLowerCase();

                $('.filtrado').hide();

                if (skill_nivel == 0 && skill_alineamiento == 0 && skill_tipo == 0 && skill_texto == "") {
                    $('.filtrado').show();
                } else {
                    if (skill_nivel != 0 && skill_alineamiento == 0 && skill_tipo == 0) {
                        $('#tabla_skills_resumido').find('tr[skill_nivel="' + skill_nivel + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel != 0 && skill_alineamiento != 0 && skill_tipo == 0) {
                        $('#tabla_skills_resumido').find('tr[skill_nivel="' + skill_nivel + '"][skill_alineamiento="' + skill_alineamiento + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel != 0 && skill_alineamiento != 0 && skill_tipo != 0) {
                        $('#tabla_skills_resumido').find('tr[skill_nivel="' + skill_nivel + '"][skill_alineamiento="' + skill_alineamiento + '"][ skill_tipo="' + skill_tipo + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel == 0 && skill_alineamiento != 0 && skill_tipo == 0) {
                        $('#tabla_skills_resumido').find('tr[skill_alineamiento="' + skill_alineamiento + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel == 0 && skill_alineamiento != 0 && skill_tipo != 0) {
                        $('#tabla_skills_resumido').find('tr[skill_alineamiento="' + skill_alineamiento + '"][ skill_tipo="' + skill_tipo + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel == 0 && skill_alineamiento == 0 && skill_tipo != 0) {
                        $('#tabla_skills_resumido').find('tr[skill_tipo="' + skill_tipo + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel != 0 && skill_alineamiento == 0 && skill_tipo != 0) {
                        $('#tabla_skills_resumido').find('tr[skill_nivel="' + skill_nivel + '"][ skill_tipo="' + skill_tipo + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel == 0 && skill_alineamiento == 0 && skill_tipo == 0 && skill_texto != "") {
                        $('#tabla_skills_resumido tr').filter(function () {
                            $(this).toggle($(this).text().toLowerCase().indexOf(skill_texto) > -1);
                        });
                    }

                }
            });

            $('.btn_skill_select').click(function (e) {
                e.preventDefault();
                var id_skill = $(this).attr("id_skill");
                var personaje_id = $('#id_personaje').val();
                //alert(id_skill);
                //alert(personaje_id);
                var skill_asignado = { id_personaje: personaje_id, id_skill: id_skill};

                $.post("/asoc_personaje_skill/Asignar", skill_asignado);
                
            });
            
        } else {
            $('#id_personaje').append($('<option>', {
                value: 0,
                text: 'Todos'
            }));

            $('#id_personaje').val(0);

            $('#id_personaje').change(function () {
                var id_pj = $('#id_personaje').val();

                $('.filtrado').hide();

                if (id_pj == 0) {
                    $('.filtrado').show();
                } else {
                    $('#tabla_asignacion_skill_pj').find('tr[id_pj="' + id_pj + '"]').show();
                }


            });
        }

        
    }

    if (pagina.indexOf("/asoc_personaje_item") !== -1) {
        if ((pagina.indexOf("/asoc_personaje_item/Edit/") !== -1) || (pagina.indexOf("/asoc_personaje_item/Create") !== -1)) {
            $('#categoria').change(function () {
                var item_categoria = $('#categoria').val();
                var item_clasificacion = $('#clasificacion').val();
                var item_tipo = $('#tipo').val();

                $('.filtrado').hide();

                if (item_categoria == 0 && item_clasificacion == 0 && item_tipo == 0) {
                    $('.filtrado').show();
                } else {
                    if (item_categoria != 0 && item_clasificacion == 0 && item_tipo == 0) {
                        $('#tabla_items_resumido').find('tr[item_categoria="' + item_categoria + '"]').show();
                    }
                    if (item_categoria != 0 && item_clasificacion != 0 && item_tipo == 0) {
                        $('#tabla_items_resumido').find('tr[item_categoria="' + item_categoria + '"][item_clasificacion="' + item_clasificacion + '"]').show();
                    }
                    if (item_categoria != 0 && item_clasificacion != 0 && item_tipo != 0) {
                        $('#tabla_items_resumido').find('tr[item_categoria="' + item_categoria + '"][item_clasificacion="' + item_clasificacion + '"][ item_tipo="' + item_tipo + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion != 0 && item_tipo == 0) {
                        $('#tabla_items_resumido').find('tr[item_clasificacion="' + item_clasificacion + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion != 0 && item_tipo != 0) {
                        $('#tabla_items_resumido').find('tr[item_clasificacion="' + item_clasificacion + '"][ item_tipo="' + item_tipo + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion == 0 && item_tipo != 0) {
                        $('#tabla_items_resumido').find('tr[item_tipo="' + item_tipo + '"]').show();
                    }
                    if (item_categoria != 0 && item_clasificacion == 0 && item_tipo != 0) {
                        $('#tabla_items_resumido').find('tr[item_categoria="' + item_categoria + '"][ item_tipo="' + item_tipo + '"]').show();
                    }
                }
            });
            $('#clasificacion').change(function () {
                var item_categoria = $('#categoria').val();
                var item_clasificacion = $('#clasificacion').val();
                var item_tipo = $('#tipo').val();

                $('.filtrado').hide();

                if (item_categoria == 0 && item_clasificacion == 0 && item_tipo == 0) {
                    $('.filtrado').show();
                } else {
                    if (item_categoria != 0 && item_clasificacion == 0 && item_tipo == 0) {
                        $('#tabla_items_resumido').find('tr[item_categoria="' + item_categoria + '"]').show();
                    }
                    if (item_categoria != 0 && item_clasificacion != 0 && item_tipo == 0) {
                        $('#tabla_items_resumido').find('tr[item_categoria="' + item_categoria + '"][item_clasificacion="' + item_clasificacion + '"]').show();
                    }
                    if (item_categoria != 0 && item_clasificacion != 0 && item_tipo != 0) {
                        $('#tabla_items_resumido').find('tr[item_categoria="' + item_categoria + '"][item_clasificacion="' + item_clasificacion + '"][ item_tipo="' + item_tipo + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion != 0 && item_tipo == 0) {
                        $('#tabla_items_resumido').find('tr[item_clasificacion="' + item_clasificacion + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion != 0 && item_tipo != 0) {
                        $('#tabla_items_resumido').find('tr[item_clasificacion="' + item_clasificacion + '"][ item_tipo="' + item_tipo + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion == 0 && item_tipo != 0) {
                        $('#tabla_items_resumido').find('tr[item_tipo="' + item_tipo + '"]').show();
                    }
                    if (item_categoria != 0 && item_clasificacion == 0 && item_tipo != 0) {
                        $('#tabla_items_resumido').find('tr[item_categoria="' + item_categoria + '"][ item_tipo="' + item_tipo + '"]').show();
                    }
                }
            });
            $('#tipo').change(function () {
                var item_categoria = $('#categoria').val();
                var item_clasificacion = $('#clasificacion').val();
                var item_tipo = $('#tipo').val();

                $('.filtrado').hide();

                if (item_categoria == 0 && item_clasificacion == 0 && item_tipo == 0) {
                    $('.filtrado').show();
                } else {
                    if (item_categoria != 0 && item_clasificacion == 0 && item_tipo == 0) {
                        $('#tabla_items_resumido').find('tr[item_categoria="' + item_categoria + '"]').show();
                    }
                    if (item_categoria != 0 && item_clasificacion != 0 && item_tipo == 0) {
                        $('#tabla_items_resumido').find('tr[item_categoria="' + item_categoria + '"][item_clasificacion="' + item_clasificacion + '"]').show();
                    }
                    if (item_categoria != 0 && item_clasificacion != 0 && item_tipo != 0) {
                        $('#tabla_items_resumido').find('tr[item_categoria="' + item_categoria + '"][item_clasificacion="' + item_clasificacion + '"][ item_tipo="' + item_tipo + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion != 0 && item_tipo == 0) {
                        $('#tabla_items_resumido').find('tr[item_clasificacion="' + item_clasificacion + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion != 0 && item_tipo != 0) {
                        $('#tabla_items_resumido').find('tr[item_clasificacion="' + item_clasificacion + '"][ item_tipo="' + item_tipo + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion == 0 && item_tipo != 0) {
                        $('#tabla_items_resumido').find('tr[item_tipo="' + item_tipo + '"]').show();
                    }
                    if (item_categoria != 0 && item_clasificacion == 0 && item_tipo != 0) {
                        $('#tabla_items_resumido').find('tr[item_categoria="' + item_categoria + '"][ item_tipo="' + item_tipo + '"]').show();
                    }
                }
            });

            $('.btn_item_select').click(function (e) {
                e.preventDefault();
                var id_item = $(this).attr("id_item");
                var personaje_id = $('#id_personaje').val();
                var cantidad = $("#cantidad_item_" + id_item).val();
                var equipado = $("#equipado_item_" + id_item).prop("checked");
                //alert(equipado);
                //alert(personaje_id);
                var item_asignado = { id_personaje: personaje_id, id_item: id_item, cantidad: cantidad, equipado: equipado };

                $.post("/asoc_personaje_item/Asignar", item_asignado);

            });
            
        } else {

            $('#id_personaje').append($('<option>', {
                value: 0,
                text: 'Todos'
            }));

            $('#id_personaje').val(0);

            $('#id_personaje').change(function () {
                var id_pj = $('#id_personaje').val();

                $('.filtrado').hide();

                if (id_pj == 0) {
                    $('.filtrado').show();
                } else {
                    $('#tabla_asignacion_item_pj').find('tr[id_pj="' + id_pj + '"]').show();
                }


            });
        }
    }

    if (pagina.indexOf("/items") !== -1) {
        if ((pagina.indexOf("/items/Edit/") !== -1) || (pagina.indexOf("/items/Create") !== -1)) {
            $('#btn_crear_item').click(function (e) {
                e.preventDefault();

                var item_nombre = $('#item_item_nombre').val();
                var categoria = $('#categoria').val();
                var clasificacion = $('#clasificacion').val();
                var tipo = $('#tipo').val();
                var item_tier = $('#item_item_tier').val();
                var item_descripcion = $('#item_item_descripcion').val();
                var item_bonificacion = $('#item_item_bonificacion').val();
                var item_atk = $('#item_item_atk').val();
                var item_mag_atk = $('#item_item_mag_atk').val();
                var item_def = $('#item_item_def').val();
                var item_mag_def = $('#item_item_mag_def').val();
                var item_imagen_nombre = $('#item_item_imagen_nombre').val();
                var item_peso = $('#item_peso').val();

                var item = {
                    item_nombre: item_nombre, item_categoria: categoria, item_clasificacion: clasificacion, item_tipo: tipo,
                    item_tier: item_tier,
                    item_descripcion: item_descripcion, item_bonificacion: item_bonificacion, item_atk: item_atk,
                    item_mag_atk: item_mag_atk, item_def: item_def, item_mag_def: item_mag_def, item_imagen_nombre: item_imagen_nombre, peso: item_peso
                };
                 
                $.post("/items/Create", item);

                window.location.replace("/items/");

            });
            $('#btn_editar_item').click(function (e) {
                e.preventDefault();
                var item_id = $('#item_id_item').val();
                var item_nombre = $('#item_item_nombre').val();
                var categoria = $('#categoria').val();
                var clasificacion = $('#clasificacion').val();
                var tipo = $('#tipo').val();
                var item_tier = $('#item_item_tier').val();
                var item_descripcion = $('#item_item_descripcion').val();
                var item_bonificacion = $('#item_item_bonificacion').val();
                var item_atk = $('#item_item_atk').val();
                var item_mag_atk = $('#item_item_mag_atk').val();
                var item_def = $('#item_item_def').val();
                var item_mag_def = $('#item_item_mag_def').val();
                var item_imagen_nombre = $('#item_item_imagen_nombre').val();
                var item_peso = $('#item_peso').val();
                
                var item = {
                    id_item: item_id, item_nombre: item_nombre, item_categoria: categoria, item_clasificacion: clasificacion, item_tipo: tipo,
                    item_tier: item_tier,
                    item_descripcion: item_descripcion, item_bonificacion: item_bonificacion, item_atk: item_atk,
                    item_mag_atk: item_mag_atk, item_def: item_def, item_mag_def: item_mag_def, item_imagen_nombre: item_imagen_nombre, peso: item_peso
                };

                //alert(categoria);
                //alert(clasificacion);
                //alert(tipo);
                $.post("/items/Edit", item);

                window.location.replace("/items/");

            });


        } else {
            $('#categoria').change(function () {
                var item_categoria = $('#categoria').val();
                var item_clasificacion = $('#clasificacion').val();
                var item_tipo = $('#tipo').val();
                var item_tier = $('#tier').val();

                $('.filtrado').hide();

                if (item_categoria == 0 && item_clasificacion == 0 && item_tipo == 0 && item_tier == 0) {
                    $('.filtrado').show();
                } else {
                    if (item_categoria != 0 && item_clasificacion == 0 && item_tipo == 0 && item_tier == 0) {
                        $('#tabla_items').find('tr[item_categoria="' + item_categoria + '"]').show();
                    }
                    if (item_categoria != 0 && item_clasificacion != 0 && item_tipo == 0 && item_tier == 0) {
                        $('#tabla_items').find('tr[item_categoria="' + item_categoria + '"][item_clasificacion="' + item_clasificacion + '"]').show();
                    }
                    if (item_categoria != 0 && item_clasificacion != 0 && item_tipo != 0 && item_tier == 0) {
                        $('#tabla_items').find('tr[item_categoria="' + item_categoria + '"][item_clasificacion="' + item_clasificacion + '"][ item_tipo="' + item_tipo + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion != 0 && item_tipo == 0 && item_tier == 0) {
                        $('#tabla_items').find('tr[item_clasificacion="' + item_clasificacion + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion != 0 && item_tipo != 0 && item_tier == 0) {
                        $('#tabla_items').find('tr[item_clasificacion="' + item_clasificacion + '"][ item_tipo="' + item_tipo + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion == 0 && item_tipo != 0 && item_tier == 0) {
                        $('#tabla_items').find('tr[item_tipo="' + item_tipo + '"]').show();
                    }
                    if (item_categoria != 0 && item_clasificacion == 0 && item_tipo != 0 && item_tier == 0) {
                        $('#tabla_items').find('tr[item_categoria="' + item_categoria + '"][ item_tipo="' + item_tipo + '"]').show();
                    }

                    if (item_categoria != 0 && item_clasificacion == 0 && item_tipo == 0 && item_tier != 0) {
                        $('#tabla_items').find('tr[item_categoria="' + item_categoria + '"][item_tier="' + item_tier + '"]').show();
                    }
                    if (item_categoria != 0 && item_clasificacion != 0 && item_tipo == 0 && item_tier != 0) {
                        $('#tabla_items').find('tr[item_categoria="' + item_categoria + '"][item_clasificacion="' + item_clasificacion + '"][item_tier="' + item_tier + '"]').show();
                    }
                    if (item_categoria != 0 && item_clasificacion != 0 && item_tipo != 0 && item_tier != 0) {
                        $('#tabla_items').find('tr[item_categoria="' + item_categoria + '"][item_clasificacion="' + item_clasificacion + '"][ item_tipo="' + item_tipo + '"][item_tier="' + item_tier + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion != 0 && item_tipo == 0 && item_tier != 0) {
                        $('#tabla_items').find('tr[item_clasificacion="' + item_clasificacion + '"][item_tier="' + item_tier + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion != 0 && item_tipo != 0 && item_tier != 0) {
                        $('#tabla_items').find('tr[item_clasificacion="' + item_clasificacion + '"][ item_tipo="' + item_tipo + '"][item_tier="' + item_tier + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion == 0 && item_tipo != 0 && item_tier != 0) {
                        $('#tabla_items').find('tr[item_tipo="' + item_tipo + '"][item_tier="' + item_tier + '"]').show();
                    }
                    if (item_categoria != 0 && item_clasificacion == 0 && item_tipo != 0 && item_tier != 0) {
                        $('#tabla_items').find('tr[item_categoria="' + item_categoria + '"][ item_tipo="' + item_tipo + '"][item_tier="' + item_tier + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion == 0 && item_tipo == 0 && item_tier != 0) {
                        $('#tabla_items').find('tr[item_tier="' + item_tier + '"]').show();
                    }
                }
            });
            $('#tier').change(function () {
                var item_categoria = $('#categoria').val();
                var item_clasificacion = $('#clasificacion').val();
                var item_tipo = $('#tipo').val();
                var item_tier = $('#tier').val();

                $('.filtrado').hide();

                if (item_categoria == 0 && item_clasificacion == 0 && item_tipo == 0 && item_tier == 0) {
                    $('.filtrado').show();
                } else {
                    if (item_categoria != 0 && item_clasificacion == 0 && item_tipo == 0 && item_tier == 0) {
                        $('#tabla_items').find('tr[item_categoria="' + item_categoria + '"]').show();
                    }
                    if (item_categoria != 0 && item_clasificacion != 0 && item_tipo == 0 && item_tier == 0) {
                        $('#tabla_items').find('tr[item_categoria="' + item_categoria + '"][item_clasificacion="' + item_clasificacion + '"]').show();
                    }
                    if (item_categoria != 0 && item_clasificacion != 0 && item_tipo != 0 && item_tier == 0) {
                        $('#tabla_items').find('tr[item_categoria="' + item_categoria + '"][item_clasificacion="' + item_clasificacion + '"][ item_tipo="' + item_tipo + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion != 0 && item_tipo == 0 && item_tier == 0) {
                        $('#tabla_items').find('tr[item_clasificacion="' + item_clasificacion + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion != 0 && item_tipo != 0 && item_tier == 0) {
                        $('#tabla_items').find('tr[item_clasificacion="' + item_clasificacion + '"][ item_tipo="' + item_tipo + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion == 0 && item_tipo != 0 && item_tier == 0) {
                        $('#tabla_items').find('tr[item_tipo="' + item_tipo + '"]').show();
                    }
                    if (item_categoria != 0 && item_clasificacion == 0 && item_tipo != 0 && item_tier == 0) {
                        $('#tabla_items').find('tr[item_categoria="' + item_categoria + '"][ item_tipo="' + item_tipo + '"]').show();
                    }

                    if (item_categoria != 0 && item_clasificacion == 0 && item_tipo == 0 && item_tier != 0) {
                        $('#tabla_items').find('tr[item_categoria="' + item_categoria + '"][item_tier="' + item_tier + '"]').show();
                    }
                    if (item_categoria != 0 && item_clasificacion != 0 && item_tipo == 0 && item_tier != 0) {
                        $('#tabla_items').find('tr[item_categoria="' + item_categoria + '"][item_clasificacion="' + item_clasificacion + '"][item_tier="' + item_tier + '"]').show();
                    }
                    if (item_categoria != 0 && item_clasificacion != 0 && item_tipo != 0 && item_tier != 0) {
                        $('#tabla_items').find('tr[item_categoria="' + item_categoria + '"][item_clasificacion="' + item_clasificacion + '"][ item_tipo="' + item_tipo + '"][item_tier="' + item_tier + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion != 0 && item_tipo == 0 && item_tier != 0) {
                        $('#tabla_items').find('tr[item_clasificacion="' + item_clasificacion + '"][item_tier="' + item_tier + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion != 0 && item_tipo != 0 && item_tier != 0) {
                        $('#tabla_items').find('tr[item_clasificacion="' + item_clasificacion + '"][ item_tipo="' + item_tipo + '"][item_tier="' + item_tier + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion == 0 && item_tipo != 0 && item_tier != 0) {
                        $('#tabla_items').find('tr[item_tipo="' + item_tipo + '"][item_tier="' + item_tier + '"]').show();
                    }
                    if (item_categoria != 0 && item_clasificacion == 0 && item_tipo != 0 && item_tier != 0) {
                        $('#tabla_items').find('tr[item_categoria="' + item_categoria + '"][ item_tipo="' + item_tipo + '"][item_tier="' + item_tier + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion == 0 && item_tipo == 0 && item_tier != 0) {
                        $('#tabla_items').find('tr[item_tier="' + item_tier + '"]').show();
                    }

                }
            });

            $('#clasificacion').change(function () {
                var item_categoria = $('#categoria').val();
                var item_clasificacion = $('#clasificacion').val();
                var item_tipo = $('#tipo').val();
                var item_tier = $('#tier').val();

                $('.filtrado').hide();

                if (item_categoria == 0 && item_clasificacion == 0 && item_tipo == 0 && item_tier == 0) {
                    $('.filtrado').show();
                } else {
                    if (item_categoria != 0 && item_clasificacion == 0 && item_tipo == 0 && item_tier == 0) {
                        $('#tabla_items').find('tr[item_categoria="' + item_categoria + '"]').show();
                    }
                    if (item_categoria != 0 && item_clasificacion != 0 && item_tipo == 0 && item_tier == 0) {
                        $('#tabla_items').find('tr[item_categoria="' + item_categoria + '"][item_clasificacion="' + item_clasificacion + '"]').show();
                    }
                    if (item_categoria != 0 && item_clasificacion != 0 && item_tipo != 0 && item_tier == 0) {
                        $('#tabla_items').find('tr[item_categoria="' + item_categoria + '"][item_clasificacion="' + item_clasificacion + '"][ item_tipo="' + item_tipo + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion != 0 && item_tipo == 0 && item_tier == 0) {
                        $('#tabla_items').find('tr[item_clasificacion="' + item_clasificacion + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion != 0 && item_tipo != 0 && item_tier == 0) {
                        $('#tabla_items').find('tr[item_clasificacion="' + item_clasificacion + '"][ item_tipo="' + item_tipo + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion == 0 && item_tipo != 0 && item_tier == 0) {
                        $('#tabla_items').find('tr[item_tipo="' + item_tipo + '"]').show();
                    }
                    if (item_categoria != 0 && item_clasificacion == 0 && item_tipo != 0 && item_tier == 0) {
                        $('#tabla_items').find('tr[item_categoria="' + item_categoria + '"][ item_tipo="' + item_tipo + '"]').show();
                    }

                    if (item_categoria != 0 && item_clasificacion == 0 && item_tipo == 0 && item_tier != 0) {
                        $('#tabla_items').find('tr[item_categoria="' + item_categoria + '"][item_tier="' + item_tier + '"]').show();
                    }
                    if (item_categoria != 0 && item_clasificacion != 0 && item_tipo == 0 && item_tier != 0) {
                        $('#tabla_items').find('tr[item_categoria="' + item_categoria + '"][item_clasificacion="' + item_clasificacion + '"][item_tier="' + item_tier + '"]').show();
                    }
                    if (item_categoria != 0 && item_clasificacion != 0 && item_tipo != 0 && item_tier != 0) {
                        $('#tabla_items').find('tr[item_categoria="' + item_categoria + '"][item_clasificacion="' + item_clasificacion + '"][ item_tipo="' + item_tipo + '"][item_tier="' + item_tier + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion != 0 && item_tipo == 0 && item_tier != 0) {
                        $('#tabla_items').find('tr[item_clasificacion="' + item_clasificacion + '"][item_tier="' + item_tier + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion != 0 && item_tipo != 0 && item_tier != 0) {
                        $('#tabla_items').find('tr[item_clasificacion="' + item_clasificacion + '"][ item_tipo="' + item_tipo + '"][item_tier="' + item_tier + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion == 0 && item_tipo != 0 && item_tier != 0) {
                        $('#tabla_items').find('tr[item_tipo="' + item_tipo + '"][item_tier="' + item_tier + '"]').show();
                    }
                    if (item_categoria != 0 && item_clasificacion == 0 && item_tipo != 0 && item_tier != 0) {
                        $('#tabla_items').find('tr[item_categoria="' + item_categoria + '"][ item_tipo="' + item_tipo + '"][item_tier="' + item_tier + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion == 0 && item_tipo == 0 && item_tier != 0) {
                        $('#tabla_items').find('tr[item_tier="' + item_tier + '"]').show();
                    }

                }
            });
            $('#tipo').change(function () {
                var item_categoria = $('#categoria').val();
                var item_clasificacion = $('#clasificacion').val();
                var item_tipo = $('#tipo').val();
                var item_tier = $('#tier').val();

                $('.filtrado').hide();

                if (item_categoria == 0 && item_clasificacion == 0 && item_tipo == 0 && item_tier==0) {
                    $('.filtrado').show();
                } else {
                    if (item_categoria != 0 && item_clasificacion == 0 && item_tipo == 0 && item_tier == 0) {
                        $('#tabla_items').find('tr[item_categoria="' + item_categoria + '"]').show();
                    }
                    if (item_categoria != 0 && item_clasificacion != 0 && item_tipo == 0 && item_tier == 0) {
                        $('#tabla_items').find('tr[item_categoria="' + item_categoria + '"][item_clasificacion="' + item_clasificacion + '"]').show();
                    }
                    if (item_categoria != 0 && item_clasificacion != 0 && item_tipo != 0 && item_tier == 0) {
                        $('#tabla_items').find('tr[item_categoria="' + item_categoria + '"][item_clasificacion="' + item_clasificacion + '"][ item_tipo="' + item_tipo + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion != 0 && item_tipo == 0 && item_tier == 0) {
                        $('#tabla_items').find('tr[item_clasificacion="' + item_clasificacion + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion != 0 && item_tipo != 0 && item_tier == 0) {
                        $('#tabla_items').find('tr[item_clasificacion="' + item_clasificacion + '"][ item_tipo="' + item_tipo + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion == 0 && item_tipo != 0 && item_tier == 0) {
                        $('#tabla_items').find('tr[item_tipo="' + item_tipo + '"]').show();
                    }
                    if (item_categoria != 0 && item_clasificacion == 0 && item_tipo != 0 && item_tier == 0) {
                        $('#tabla_items').find('tr[item_categoria="' + item_categoria + '"][ item_tipo="' + item_tipo + '"]').show();
                    }

                    if (item_categoria != 0 && item_clasificacion == 0 && item_tipo == 0 && item_tier != 0) {
                        $('#tabla_items').find('tr[item_categoria="' + item_categoria + '"][item_tier="' + item_tier + '"]').show();
                    }
                    if (item_categoria != 0 && item_clasificacion != 0 && item_tipo == 0 && item_tier != 0) {
                        $('#tabla_items').find('tr[item_categoria="' + item_categoria + '"][item_clasificacion="' + item_clasificacion + '"][item_tier="' + item_tier + '"]').show();
                    }
                    if (item_categoria != 0 && item_clasificacion != 0 && item_tipo != 0 && item_tier != 0) {
                        $('#tabla_items').find('tr[item_categoria="' + item_categoria + '"][item_clasificacion="' + item_clasificacion + '"][ item_tipo="' + item_tipo + '"][item_tier="' + item_tier + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion != 0 && item_tipo == 0 && item_tier != 0) {
                        $('#tabla_items').find('tr[item_clasificacion="' + item_clasificacion + '"][item_tier="' + item_tier + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion != 0 && item_tipo != 0 && item_tier != 0) {
                        $('#tabla_items').find('tr[item_clasificacion="' + item_clasificacion + '"][ item_tipo="' + item_tipo + '"][item_tier="' + item_tier + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion == 0 && item_tipo != 0 && item_tier != 0) {
                        $('#tabla_items').find('tr[item_tipo="' + item_tipo + '"][item_tier="' + item_tier + '"]').show();
                    }
                    if (item_categoria != 0 && item_clasificacion == 0 && item_tipo != 0 && item_tier != 0) {
                        $('#tabla_items').find('tr[item_categoria="' + item_categoria + '"][ item_tipo="' + item_tipo + '"][item_tier="' + item_tier + '"]').show();
                    }
                    if (item_categoria == 0 && item_clasificacion == 0 && item_tipo == 0 && item_tier != 0) {
                        $('#tabla_items').find('tr[item_tier="' + item_tier + '"]').show();
                    }
                }
            });
        }
        
    }

    if (pagina.indexOf("/skills") !== -1) {
        if ((pagina.indexOf("/skills/Edit/") !== -1) || (pagina.indexOf("/skills/Create") !== -1)) {
            $('#btn_crear_skill').click(function (e) {
                e.preventDefault();

                var skill_nombre = $('#skill_skill_nombre').val();
                var skill_nivel = $('#skill_nivel').val();
                var skill_tipo = $('#skill_tipo').val();
                var skill_atributo = $('#skill_atributo').val();
                var skill_costo = $('#skill_skill_costo').val();
                var skill_tipo_efecto = $('#skill_skill_tipo_efecto').val();
                var skill_danio = $('#skill_skill_danio').val();
                var skill_dado_basico = $('#skill_skill_dado_basico').val();
                var skill_requisito = $('#skill_skill_requisito').val();

                var skill = {
                    skill_nombre: skill_nombre, skill_nivel: skill_nivel, skill_tipo: skill_tipo, skill_atributo: skill_atributo,
                    skill_costo: skill_costo, skill_tipo_efecto: skill_tipo_efecto, skill_danio: skill_danio,
                    skill_dado_basico: skill_dado_basico, skill_requisito: skill_requisito
                };

                $.post("/skills/Create", skill);

                window.location.replace("/skills/");

            });
            $('#btn_editar_skill').click(function (e) {
                e.preventDefault();

                var skill_id = $('#skill_id_skill').val();
                var skill_nombre = $('#skill_skill_nombre').val();
                var skill_nivel = $('#skill_nivel').val();
                var skill_tipo = $('#skill_tipo').val();
                var skill_atributo = $('#skill_atributo').val();
                var skill_costo = $('#skill_skill_costo').val();
                var skill_tipo_efecto = $('#skill_skill_tipo_efecto').val();
                var skill_danio = $('#skill_skill_danio').val();
                var skill_dado_basico = $('#skill_skill_dado_basico').val();
                var skill_requisito = $('#skill_skill_requisito').val();
                var skill_alineamiento = $('#skill_alineamiento').val();

                var skill = {
                    id_skill: skill_id,
                    skill_nombre: skill_nombre, skill_nivel: skill_nivel, skill_tipo: skill_tipo, skill_atributo: skill_atributo,
                    skill_costo: skill_costo, skill_tipo_efecto: skill_tipo_efecto, skill_danio: skill_danio,
                    skill_dado_basico: skill_dado_basico, skill_requisito: skill_requisito, skill_alineamiento: skill_alineamiento
                };

                $.post("/skills/Edit", skill);

                window.location.replace("/skills/");

            });

        } else {
            $('#filtro_skills_nombre').on('keyup', function () {
                var skill_nivel = $('#skill_nivel').val();
                var skill_alineamiento = $('#skill_alineamiento').val();
                var skill_tipo = $('#skill_tipo').val();
                var skill_texto = $('#filtro_skills_nombre').val().toLowerCase();

                $('.filtrado').hide();

                if (skill_nivel == 0 && skill_alineamiento == 0 && skill_tipo == 0 && skill_texto == "") {
                    $('.filtrado').show();
                } else {
                    if (skill_nivel != 0 && skill_alineamiento == 0 && skill_tipo == 0) {
                        $('#tabla_skills').find('tr[skill_nivel="' + skill_nivel + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel != 0 && skill_alineamiento != 0 && skill_tipo == 0) {
                        $('#tabla_skills').find('tr[skill_nivel="' + skill_nivel + '"][skill_alineamiento="' + skill_alineamiento + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel != 0 && skill_alineamiento != 0 && skill_tipo != 0) {
                        $('#tabla_skills').find('tr[skill_nivel="' + skill_nivel + '"][skill_alineamiento="' + skill_alineamiento + '"][ skill_tipo="' + skill_tipo + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel == 0 && skill_alineamiento != 0 && skill_tipo == 0) {
                        $('#tabla_skills').find('tr[skill_alineamiento="' + skill_alineamiento + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel == 0 && skill_alineamiento != 0 && skill_tipo != 0) {
                        $('#tabla_skills').find('tr[skill_alineamiento="' + skill_alineamiento + '"][ skill_tipo="' + skill_tipo + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel == 0 && skill_alineamiento == 0 && skill_tipo != 0) {
                        $('#tabla_skills').find('tr[skill_tipo="' + skill_tipo + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel != 0 && skill_alineamiento == 0 && skill_tipo != 0) {
                        $('#tabla_skills').find('tr[skill_nivel="' + skill_nivel + '"][ skill_tipo="' + skill_tipo + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel == 0 && skill_alineamiento == 0 && skill_tipo == 0 && skill_texto != "") {
                        $('#tabla_skills tr').filter(function () {
                            $(this).toggle($(this).text().toLowerCase().indexOf(skill_texto) > -1);
                        });
                    }

                }
                $('.filtrado_titulo').show();
            });


            $('#skill_nivel').change(function () {
                var skill_nivel = $('#skill_nivel').val();
                var skill_alineamiento = $('#skill_alineamiento').val();
                var skill_tipo = $('#skill_tipo').val();
                var skill_texto = $('#filtro_skills_nombre').val().toLowerCase();

                $('.filtrado').hide();

                if (skill_nivel == 0 && skill_alineamiento == 0 && skill_tipo == 0 && skill_texto == "") {
                    $('.filtrado').show();
                } else {
                    if (skill_nivel != 0 && skill_alineamiento == 0 && skill_tipo == 0) {
                        $('#tabla_skills').find('tr[skill_nivel="' + skill_nivel + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel != 0 && skill_alineamiento != 0 && skill_tipo == 0) {
                        $('#tabla_skills').find('tr[skill_nivel="' + skill_nivel + '"][skill_alineamiento="' + skill_alineamiento + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel != 0 && skill_alineamiento != 0 && skill_tipo != 0) {
                        $('#tabla_skills').find('tr[skill_nivel="' + skill_nivel + '"][skill_alineamiento="' + skill_alineamiento + '"][ skill_tipo="' + skill_tipo + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel == 0 && skill_alineamiento != 0 && skill_tipo == 0) {
                        $('#tabla_skills').find('tr[skill_alineamiento="' + skill_alineamiento + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel == 0 && skill_alineamiento != 0 && skill_tipo != 0) {
                        $('#tabla_skills').find('tr[skill_alineamiento="' + skill_alineamiento + '"][ skill_tipo="' + skill_tipo + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel == 0 && skill_alineamiento == 0 && skill_tipo != 0) {
                        $('#tabla_skills').find('tr[skill_tipo="' + skill_tipo + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel != 0 && skill_alineamiento == 0 && skill_tipo != 0) {
                        $('#tabla_skills').find('tr[skill_nivel="' + skill_nivel + '"][ skill_tipo="' + skill_tipo + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel == 0 && skill_alineamiento == 0 && skill_tipo == 0 && skill_texto != "") {
                        $('#tabla_skills tr').filter(function () {
                            $(this).toggle($(this).text().toLowerCase().indexOf(skill_texto) > -1);
                        });
                    }
                }
                $('.filtrado_titulo').show();
            });

            $('#skill_alineamiento').change(function () {
                var skill_nivel = $('#skill_nivel').val();
                var skill_alineamiento = $('#skill_alineamiento').val();
                var skill_tipo = $('#skill_tipo').val();
                var skill_texto = $('#filtro_skills_nombre').val().toLowerCase();

                $('.filtrado').hide();

                if (skill_nivel == 0 && skill_alineamiento == 0 && skill_tipo == 0 && skill_texto == "") {
                    $('.filtrado').show();
                } else {
                    if (skill_nivel != 0 && skill_alineamiento == 0 && skill_tipo == 0) {
                        $('#tabla_skills').find('tr[skill_nivel="' + skill_nivel + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel != 0 && skill_alineamiento != 0 && skill_tipo == 0) {
                        $('#tabla_skills').find('tr[skill_nivel="' + skill_nivel + '"][skill_alineamiento="' + skill_alineamiento + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel != 0 && skill_alineamiento != 0 && skill_tipo != 0) {
                        $('#tabla_skills').find('tr[skill_nivel="' + skill_nivel + '"][skill_alineamiento="' + skill_alineamiento + '"][ skill_tipo="' + skill_tipo + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel == 0 && skill_alineamiento != 0 && skill_tipo == 0) {
                        $('#tabla_skills').find('tr[skill_alineamiento="' + skill_alineamiento + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel == 0 && skill_alineamiento != 0 && skill_tipo != 0) {
                        $('#tabla_skills').find('tr[skill_alineamiento="' + skill_alineamiento + '"][ skill_tipo="' + skill_tipo + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel == 0 && skill_alineamiento == 0 && skill_tipo != 0) {
                        $('#tabla_skills').find('tr[skill_tipo="' + skill_tipo + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel != 0 && skill_alineamiento == 0 && skill_tipo != 0) {
                        $('#tabla_skills').find('tr[skill_nivel="' + skill_nivel + '"][ skill_tipo="' + skill_tipo + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel == 0 && skill_alineamiento == 0 && skill_tipo == 0 && skill_texto != "") {
                        $('#tabla_skills tr').filter(function () {
                            $(this).toggle($(this).text().toLowerCase().indexOf(skill_texto) > -1);
                        });
                    }
                }
                $('.filtrado_titulo').show();
            });

            $('#skill_tipo').change(function () {
                var skill_nivel = $('#skill_nivel').val();
                var skill_alineamiento = $('#skill_alineamiento').val();
                var skill_tipo = $('#skill_tipo').val();
                var skill_texto = $('#filtro_skills_nombre').val().toLowerCase();

                $('.filtrado').hide();

                if (skill_nivel == 0 && skill_alineamiento == 0 && skill_tipo == 0 && skill_texto == "") {
                    $('.filtrado').show();
                } else {
                    if (skill_nivel != 0 && skill_alineamiento == 0 && skill_tipo == 0) {
                        $('#tabla_skills').find('tr[skill_nivel="' + skill_nivel + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel != 0 && skill_alineamiento != 0 && skill_tipo == 0) {
                        $('#tabla_skills').find('tr[skill_nivel="' + skill_nivel + '"][skill_alineamiento="' + skill_alineamiento + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel != 0 && skill_alineamiento != 0 && skill_tipo != 0) {
                        $('#tabla_skills').find('tr[skill_nivel="' + skill_nivel + '"][skill_alineamiento="' + skill_alineamiento + '"][ skill_tipo="' + skill_tipo + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel == 0 && skill_alineamiento != 0 && skill_tipo == 0) {
                        $('#tabla_skills').find('tr[skill_alineamiento="' + skill_alineamiento + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel == 0 && skill_alineamiento != 0 && skill_tipo != 0) {
                        $('#tabla_skills').find('tr[skill_alineamiento="' + skill_alineamiento + '"][ skill_tipo="' + skill_tipo + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel == 0 && skill_alineamiento == 0 && skill_tipo != 0) {
                        $('#tabla_skills').find('tr[skill_tipo="' + skill_tipo + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel != 0 && skill_alineamiento == 0 && skill_tipo != 0) {
                        $('#tabla_skills').find('tr[skill_nivel="' + skill_nivel + '"][ skill_tipo="' + skill_tipo + '"]').filter(function () { var condicion = $(this).text().toLowerCase().indexOf(skill_texto) > -1; $(this).toggle(condicion); });
                    }
                    if (skill_nivel == 0 && skill_alineamiento == 0 && skill_tipo == 0 && skill_texto != "") {
                        $('#tabla_skills tr').filter(function () {
                            $(this).toggle($(this).text().toLowerCase().indexOf(skill_texto) > -1);
                        });
                    }
                }
                $('.filtrado_titulo').show();
            });
        }
        
    }

});


