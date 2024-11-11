/* eslint-disable no-unused-vars */
import React, { useEffect, useState } from 'react';
import axios from 'axios';

const TaskTable = () => {
    const [tasks, setTasks] = useState([]);

    useEffect(() => {
        axios.get('https://localhost:7004/api/tasks/GetTasks')
            .then(response => setTasks(response.data))
            .catch(error => console.error(error));
    }, []);

    return (
        <table>
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Name</th>
                    <th>Description</th>
                    <th>Status</th>
                    <th>Created Date</th>
                    <th>Last Modified Date</th>
                </tr>
            </thead>
            <tbody>
                {tasks.map(task => (
                    <tr key={task.id}>
                        <td>{task.id}</td>
                        <td>{task.name}</td>
                        <td>{task.description}</td>
                        <td>{task.status}</td>
                        <td>{new Date(task.createdDate).toLocaleDateString()}</td>
                        <td>{new Date(task.lastModifiedDate).toLocaleDateString()}</td>
                    </tr>
                ))}
            </tbody>
        </table>
    );
};

export default TaskTable;