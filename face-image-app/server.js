const express = require('express');
const path = require('path');
const cors = require('cors');

const app = express();

app.use(cors);

const serverInfoFilePath = require('./src/data/serverinfo2.json');

app.get('/api/serverinfo', (req, res) => {
    res.setHeader('Content-Type', 'application/json');
    res.json(serverInfoFilePath);
});


app.listen(8000, () => {
    console.log('json server started, listening on port 8000')
});


module.exports = app;