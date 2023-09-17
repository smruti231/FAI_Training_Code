const express = require('express');
const fs = require('fs');
const csv = require('csv-parser');

const app = express();
const port = process.env.PORT || 3000;

app.use(express.urlencoded({ extended: true }));
app.use(express.static('public'));

// Define the route to display the HTML form
app.get('/', (req, res) => {
    res.sendFile(__dirname + '/public/index.html');
});

// Define the route to handle form submission
app.post('/submit', (req, res) => {
    const { name, email } = req.body;

    // Validation: Check if name and email are not empty
    if (!name || !email) {
        return res.status(400).send('Both name and email are required.');
    }

    const data = { name, email };

    // Append data to the CSV file
    const csvData = `${data.name},${data.email}\n`;
    fs.appendFile('data.csv', csvData, (err) => {
        if (err) {
            console.error('Error appending data to CSV file:', err);
            return res.status(404).send('Internal Server Error');
        }
        console.log('Data appended to CSV file.');
        res.redirect('/');
    });
});

// Define a route to fetch and display data from the CSV file
app.get('/data', (req, res) => {
    const data = [];
    fs.createReadStream('data.csv')
        .pipe(csv())
        .on('data', (row) => {
            // console.log('CSV Row: ', row);
            data.push({ name: row.Name, email: row.Email }); // Adjust property names as needed
        })
        .on('end', () => {
            // console.log('CSV Data: ', data);
            // Create an HTML table to display the data with bootstrap
            let table = '<table class="table table-secondary table-striped">                                 <thead class="thead-dark">                                                                   <tr>                                                                                                       <th>Name</th><th>Email</th>                                                                     </tr>                                                                                   <thead>                                                                                             <tbody>';
            data.forEach((item) => {
                table += `
            <tr>
                <td>${item.name}</td>
                <td>${item.email}</td>
            </tr>
            `;
            });
            table += `
                </tbody>
                </table>
            `;
            res.send(table);
        });
});

app.listen(port, () => {
    console.log(`Server is running on port ${port}`);
});
