google.charts.load('current', { packages: ['corechart'] });
google.charts.setOnLoadCallback(drawChart);
google.charts.setOnLoadCallback(drawBarChart);

const lineList = [];
const barList = [];
const barRow = [];
const barLoads = [];

export function testChart(array) {
    lineList.push(array);
    drawChart();
}

export function setInitialLineChart() {
    lineList.splice(0, lineList.length);
    drawChart();
    barRow.splice(0, barRow.length);
    barList.splice(0, barList.length);
    drawBarChart();
}

export function setBarChart(array) {
    
    for (let i = 0; i < array.length; i++) {
        barList.push(array[i]);
    }
    
    drawBarChart();
}

function drawChart() {
    
    var data1 = new google.visualization.DataTable();
    data1.addColumn('number', 'Time');
    data1.addColumn('number', 'Weight');
    data1.addRows(lineList);

    // Set Options
    var options = {
        title: 'Current weight',
        legend: 'none',
        colors: ['#059669']
        
    };
    // Draw
    var chart = new google.visualization.LineChart(document.getElementById('myChart'));
    chart.draw(data1, options);
}

function drawBarChart() {

    var colors = ["#065f46", "#fde047"]
    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Axle');
    data.addColumn('number', 'Load');
    data.addColumn({ type: 'string', role: 'style' });
    let color = "";
    for (let i = 0; i < barList.length; i++) {
        if (i % 2 === 0) {
            color = colors[0];
        }
        else {
            color = colors[1];
        }
        barRow.push(["", barList[i], color]);
    }
    //data.addRows([["Copper", 8.94, "color:#b87333"], ["Silver", 10.49, "color:#b87333"]]);
    data.addRows(barRow);

    var options = {
        title: "Axle's load",
        bar: { groupWidth: "95%" },
        legend: { position: "none" }
    };
    var chart = new google.visualization.ColumnChart(document.getElementById("columnchart_values"));
    chart.draw(data, options);
}