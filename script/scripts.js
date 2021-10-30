function mostrarConsultar(){
  document.getElementById('consultar').style.display = 'block';
  document.getElementById('generar').style.display = 'none';
  document.getElementById('image').style.display = 'none';
}

function mostrarGenerar(){
  document.getElementById('generar').style.display = 'block';
  document.getElementById('consultar').style.display = 'none';
  document.getElementById('image').style.display = 'none';
  document.getElementById('tipo-reclamo').style.display = 'none';
  document.getElementById('detalle').style.display = 'none';
}

function mostrarTipoReclamo(){
  var tipoReclamo = document.getElementById('exampleFormControlSelect2').value;
  if (tipoReclamo == 3) {
    document.getElementById('tipo-reclamo').style.display = 'block';
    document.getElementById('detalle').style.display = 'none';
    document.getElementById('subtipo-reclamo').value = "1";
  } else if(tipoReclamo == 5){
    document.getElementById('tipo-reclamo').style.display = 'none';
    document.getElementById('detalle').style.display = 'block';
    document.getElementById('area-detalle').value = "";

  } else{
    document.getElementById('tipo-reclamo').style.display = 'none';
  } 
}
