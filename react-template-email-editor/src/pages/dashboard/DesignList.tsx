import { useEffect, useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';

const DesignList = () => {

  const navigate = useNavigate();

  const [templateMails, setTemplateMails] = useState([])
  useEffect(() => {
    fetch('http://localhost:5001/Email/template-mails')
      .then(response => response.json())
      .then(req => {
        const data = req.data;
        setTemplateMails(data)
        // var sameple1 = JSON.parse(dataJson.design);
        // console.log(req)
      });
  }, [])
  return (
    <div>
      <h1>My Designs</h1>

      <p>
        <Link to={`/dashboard/design/new`}>New Design</Link>
      </p>
      <div className='container' style={{ display: 'flex' }}>
        {templateMails.map((item: any) => {
          return (<div
            onClick={() => navigate(`/dashboard/design/edit/${item.id}`)}
            style={{ border: '1px solid #eee', margin: '4px', padding: '4px', cursor: 'pointer' }}
            key={item?.id}>{item?.name}</div>)
        })}
      </div>
    </div>
  );
};

export default DesignList;
