import { useEffect, useState } from "react"
function App() {
  const [students, setStudents] = useState([]);

    useEffect(() => {
        fetch("https://localhost:7068/students")
          .then(response => response.json())
          .then(data => setStudents(data))
          .catch(error => console.error("Error fetching students:", error));
    }, []);

    return (
        <>
            <h3>Student List</h3>

            {students.map((student) => (
            <div key={student.id}>

                <p>{student.firstName} {student.lastName}, {student.email}, {student.phoneNumber} {student.dateOfBirth}</p>

            </div>
            ))}
        </>
    )
}

export default App
