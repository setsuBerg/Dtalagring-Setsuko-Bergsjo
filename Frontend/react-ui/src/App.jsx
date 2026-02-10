import { useEffect, useState } from "react"

function App() {

    const [students, setStudents] = useState([]);

    useEffect(() => {
        fetch("https://localhost:7068/students")
          .then(response => response.json())
          .then(data => setStudents(data))
          .catch(error => console.error("Error fetching students:", error));
    }, []);

    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [email, setEmail] = useState("");
    const [phoneNumber, setPhoneNumber] = useState("");
    const [dateOfBirth, setDateOfBirth] = useState("");
    

    //Put version
    const handleAdd = async () => { 
        const newStudent = {
            firstName,
            lastName,
            email,
            phoneNumber,
            dateOfBirth
        };
        const response = await fetch("https://localhost:7068/students", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(newStudent)
        });

        if (response.ok) {
            const data = await response.json();
            setStudents([...students, data]);
        }

        setFirstName("");
        setLastName("");
        setEmail("");
        setPhoneNumber("");
        setDateOfBirth("");

    };

    return (
        <>
            <h3>Add Student</h3>
            <div>
                <input type="text" placeholder="First Name" value={firstName} onChange={(e) => setFirstName(e.target.value)} />
            </div>
            <div>
                <input type="text" placeholder="Last Name" value={lastName} onChange={(e) => setLastName(e.target.value)} />
            </div>
            <div>
                <input type="email" placeholder="Email" value={email} onChange={(e) => setEmail(e.target.value)} />
            </div>
            <div>
                <input type="text" placeholder="Phone Number" value={phoneNumber} onChange={(e) => setPhoneNumber(e.target.value)} />
            </div>
            <div>
                <input type="date" placeholder="Date of Birth" value={dateOfBirth} onChange={(e) => setDateOfBirth(e.target.value)} />
            </div>

            <button type="button" onClick={handleAdd}>Add Student</button>
            

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
