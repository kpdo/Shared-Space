// useful packages
var express = require('express');
var mustacheExpress = require('mustache-express');
var bodyParser = require('body-parser');
var { Client } = require('pg');
var port = process.env.PORT || 3000;
var app = express();
var cors = require('cors');
var http = require('http');
var server = http.Server(app);
var socket = require('socket.io');

// starting the server up
server.listen(port, ()=>{
    console.log('Server starting...');
});

// setting up index page
app.use(express.static('public'));

//Make it CORS complient
app.use(cors());

// setting up socket
var io = socket(server);
io.on('connection', (socket)=>{
    console.log('New user: ' + socket.id );
});

// logicless template engine for creating html page
const mustache = mustacheExpress();
mustache.cache = null;
app.engine('mustache', mustache);
app.set('view engine', 'mustache');

app.use(bodyParser.urlencoded({extended:false}));

// app.get('/run', (req,res)=>{
//     // calling batch file to run unity executable
//     // const execFile = require('child_process').execFile;
//     // const child = execFile('runExec.bat', [], (error, stdout, stderr) => {
//     //     if (error) {
//     //         throw error;
//     //     }
//     //     console.log(stdout);
//     // });
//     res.render('viewTest2');
// });

// uses express for routing
app.get('/testView1', (req, res)=>{
    res.render('testView1');
});
app.get('/testView2', (req, res)=>{
    res.render('testView2');
});

//RESTful Api
//POST   - insert
//PUT    - udpate
//DELETE - delele
//GET    - select

// database setup
app.get('/rooms', (req, res)=>{
    // console.log('post body', req.body);

    //uses postgres for database, can use pgAdmin or sqlShell to interact with database manually
    const client = new Client({
        user: 'vlkjlyefplkbne',
        password: '18d054f18a5e00f4185ffd5f0c97d11850b699d8edc7aa0d4a7b2424f23f67cd',
        port: 5432,
        database: 'd8ig910bf2pdj5',
        host: 'ec2-54-235-181-55.compute-1.amazonaws.com',
        ssl: true
    });

    // const client = new Client({
    //     user: 'postgres',
    //     password: 'Phuongdo123',
    //     port: 5432,
    //     database: 'user',
    //     server: 'localhost',
    // });

    // uses promise to interact with database
client.connect()
    .then(()=>{
        return client.query('SELECT * FROM rooms');
    })
    .then((results)=>{
        console.log('results?', results);
        res.render('rooms', results);
    })
    // .catch(err=>{
    //     console.log(err);
    // })
    // .then(()=>{
    //     console.log('Connection Complete');
    //     const sql = 'INSERT INTO wife (name,age,gender) VALUES ($1,$2,$3)';
    //     const params = [req.body.name,req.body.age,req.body.gender];
    //     return client.query(sql, params);
    // })
    // .then((result)=>{
    //     console.log('results?', result);
    //     res.redirect('/wifus');
    // })
    // .catch(err=>{
    //     console.log(err);
    // })
});
