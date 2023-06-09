import { useRef } from 'react';
import styled from 'styled-components';
import { Link } from 'react-router-dom';

import { EditorRef } from '../../utils/types';
import { EmailEditor } from '../../utils/EmailEditor';

const Container = styled.div`
  display: flex;
  flex-direction: column;
  position: relative;
  height: 100%;
`;

const Bar = styled.div`
  flex: 1;
  background-color: #61dafb;
  color: #000;
  padding: 10px;
  display: flex;
  max-height: 40px;

  h1 {
    flex: 1;
    font-size: 16px;
    text-align: left;
  }

  button {
    flex: 1;
    padding: 10px;
    margin-left: 10px;
    font-size: 14px;
    font-weight: bold;
    background-color: #000;
    color: #fff;
    border: 0px;
    max-width: 150px;
    cursor: pointer;
  }

  a {
    flex: 1;
    padding: 10px;
    margin-left: 10px;
    font-size: 14px;
    font-weight: bold;
    color: #fff;
    border: 0px;
    cursor: pointer;
    text-align: right;
    text-decoration: none;
    line-height: 160%;
  }
`;

const DesignNew = () => {
  const emailEditorRef = useRef<EditorRef | null>(null);

  const saveDesign = () => {
    emailEditorRef.current?.saveDesign((design) => {
      console.log('saveDesign', design);
      alert('Design JSON has been logged in your developer console.');

      const objectSave = {
        Name:"template email",
        Design:JSON.stringify(design),
        // DesignJson:design,
        DisplayMode:'email'
      }
      const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(objectSave)
        };
        fetch('http://localhost:5001/Email/saveDesign', requestOptions)
            .then(response => response.json())
            // .then(data => this.setState({ postId: data.id }));
        });
        
  };

  const exportHtml = () => {
    emailEditorRef.current?.exportHtml((data) => {
      const { html } = data;
      console.log('exportHtml', html);
      alert('Output HTML has been logged in your developer console.');
    });
  };

  return (
    <Container>
      <Bar>
        <h1>React Email Editor (Demo)</h1>

        <Link to={`/dashboard`}>Dashboard</Link>
        <button onClick={saveDesign}>Save Design</button>
        <button onClick={exportHtml}>Export HTML</button>
      </Bar>

      <EmailEditor ref={emailEditorRef} />
    </Container>
  );
};

export default DesignNew;
