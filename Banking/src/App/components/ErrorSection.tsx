import React from 'react';

const ErrorSection: React.FC<{ errors: string[] | undefined }> = ({ errors }) => {
    if (!errors || !errors.length)
        return null;

    return (
        <div className="form-errors-section">
            <div className="icon-section">
                <i className="feather icon-alert-circle" />
            </div>
            <div className="errors-section">
                <label>Errores producidos</label>
                <ul>
                    {errors.map((item, index) => (
                        <li key={index}>{item}</li>
                    ))}
                </ul>
            </div>
        </div>
    );
}

export default ErrorSection;